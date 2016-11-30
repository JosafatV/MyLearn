angular.module('mod_MyLearn').controller('ctrl_crearCuentaEstudiante', ['$q','fileUpload','$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService',
    function ($q,fileUpload,$scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService) {

        $scope.csv;
        $scope.aaa = "";
        var access_token = "";
        var refresh_token = "";
        var client_id = "";      
        $scope.universidadSelected = "";
        $scope.str_paisSelected = "";
        $scope.ls_tecnologiasSelect = [];
        $scope.ls_listaUniversidades = [];
        $scope.js_crearCuentaJson = {
            NombreContacto: "",
            ApellidoContacto: "",
            Carne: "",
            Email: "",
            Telefono: "",
            Pais: "",
            Region: "",
            RepositorioCodigo: "",
            LinkHojaDeVida: "",
            NombreDeUsuario: "",
            Contrasena: "",
            RepositorioArchivos: "",
            CredencialDrive: "",
            IdUniversidad: ""
        }

        getClientId();

        OAuth.initialize('CgKcLvAzYP_vq69R1HNBPtTne_g');
        OAuth.create('google_drive');

        $scope.js_crearTecnologia = {
            IdTecnologia: "",
            IdEstudiante: ""
        };

        fct_MyLearn_API_Client.query({ type: 'Paises' }).$promise.then(function (data) {
            $scope.lst_listaPaises = data;
        });

        fct_MyLearn_API_Client.query({ type: 'Tecnologias' }).$promise.then(function (data) {
            $scope.ls_tecnologias = data;
        });

        fct_MyLearn_API_Client.query({ type: 'Universidades' }).$promise.then(function (data) {
            $scope.ls_listaUniversidades = data;
        });

        $scope.changeUniversidad = function () {
            $scope.crearCuentaJson.IdUniversidad = $scope.universidadSelected.Id;
        };

        $scope.alertePrueba = function () {
            alert("hola");
        };

        $scope.changePais = function () {
            $scope.js_crearCuentaJson.Pais = $scope.paisSelected.Pais1;
        };

        $scope.changeUniversidad= function () {
            $scope.js_crearCuentaJson.IdUniversidad = $scope.universidadSelected.Id;
        };

        $scope.sendCuenta = function () {
            fct_MyLearn_API_Client.save({ type: 'Estudiantes' }, $scope.js_crearCuentaJson).$promise.then(function (data) {
                set_sendCredentials(data.Id);
                angular.forEach($scope.ls_tecnologiasSelect, function (value, key) {
                    fct_MyLearn_API_Client.save({ type: 'Estudiantes', extension1: "Tecnologia" },
                        { IdTecnologia: value.Id, IdEstudiante: data.Id }
                        );
                });
            });
        };

        $scope.do_doleteSelected = function (tec) {
            $scope.ls_tecnologias.push(tec);
            $scope.ls_tecnologiasSelect.splice($scope.ls_tecnologiasSelect.indexOf(tec), 1);
        };


        /*
        * Esta es la funcion encargada de recibir el clientId
        */
        function getClientId() {
            fct_MyLearn_API_Client.get({ type: 'ClientSecret' }).$promise.then(function (data) {
                client_id = data.client_id;
            });
        };

        /*
        * Esta es la funcion encargada de conectar con Drive
        */

        $scope.testDrive = function () {
            OAuth.clearCache();
            OAuth.popup('google_drive', { cache: false }).done(function (result) {
                console.log(result);
                access_token = result.access_token;
                refresh_token = result.refresh_token;
            })
        };


        /*
        * Función encargada de enviar las credential 
        */

        function set_sendCredentials(id) {
            fct_MyLearn_API_Client.save({ type: 'DriveCredentials' }, {
                "UserId": id,
                "AccessToken": access_token,
                "RefreshToken": refresh_token
            }).$promise.then(function (data) {
                alert(angular.toJson(data));
            });
        };

        /*
        * Esta es la funcion encargada de enviar el archivo a la base de datos
        */

        $scope.sendFile = function(){
            var file = $scope.myFile;
            var fd = new FormData();
            fd.append('file', file);
            console.log('file is ');
            console.dir(fd);

            fct_MyLearn_API_Client.save({ type: 'File', extension1: 1 }, {
                name: 'B.txt',
                contentType: 'text/plain',
                bytes: $scope
            }).$promise.then(function (data) {
                alert(data);
            });

        };

        $scope.onFileSelect = function() {
            reader = new FileReader();
            reader.onload = function() {
                file_contents = this.result;
                upload_file($scope.files[0],file_contents);
            };
            reader.readAsArrayBuffer($scope.files[0]);
        };

        $scope.fileChanged = function () {

            // define reader
            var reader = new FileReader();

            // A handler for the load event (just defining it, not executing it right now)
            reader.onload = function (e) {
                var fd = new FormData();
                fd.append('file', csvFile);
                $scope.$apply(function () {
                    //$scope.csvFile = reader.result;
                    //alert(reader.result);
                    fct_MyLearn_API_Client.saveFile({ type: 'File', extension1: 37 },fd).$promise.then(function (data) {
                        alert(angular.toJson(data));
                    });
                });
            };

            // get <input> element and the selected file 
            var csvFileInput = document.getElementById('fileInput');
            var csvFile = csvFileInput.files[0];
            var fileName = csvFileInput.files[0].name;
            var fileContentType = csvFileInput.files[0].type;
            alert(fileName);

            // use reader to read the selected file
            // when read operation is successfully finished the load event is triggered
            // and handled by our reader.onload function            
            //reader.readAsBinaryString(csvFile);
            //reader.readAsArrayBuffer(csvFile)
        };

        $scope.getFile = function () {
            var file = $scope.myFile;
            console.log('file is ');
            console.info(file);
        };

        $scope.do_agregueTec = function (tec) {
            $scope.ls_tecnologiasSelect.push(tec);
            $scope.ls_tecnologias.splice($scope.ls_tecnologias.indexOf(tec), 1);
        };

        $scope.goCrearCuenta = function () {
            $location.path("/MyLearn/CrearCuentaComo");
        };

        $scope.uploadFile = function () {
            var file = $scope.myFile;

            console.log('file is ');
            console.dir(file);

            var uploadUrl = "/fileUpload";
            fileUpload.uploadFileToUrl(file);
        };

    }]);



angular.module('mod_MyLearn').directive('fileModel', ['$parse', function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var model = $parse(attrs.fileModel);
            var modelSetter = model.assign;

            element.bind('change', function () {
                scope.$apply(function () {
                    modelSetter(scope, element[0].files[0]);
                });
            });
        }
    };
}]);

angular.module('mod_MyLearn').service('fileUpload', ['$http', function ($http) {
    this.uploadFileToUrl = function (file) {
        var fd = new FormData();
        fd.append('file', file);

        $http.post('http://172.19.13.20:8099/MyLearnApi/File/31', fd, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })

    }
}]);




