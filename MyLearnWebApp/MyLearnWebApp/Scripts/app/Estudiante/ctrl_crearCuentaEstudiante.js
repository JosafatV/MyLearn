angular.module('mod_MyLearn').controller('ctrl_crearCuentaEstudiante', ['$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService',
    function ($q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService) {

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

        function sendFile(){
            var file = $scope.myFile;

            console.log('file is ');
            console.dir(file);

            var uploadUrl = "/fileUpload";
            fileUpload.uploadFileToUrl(file, uploadUrl);
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

    }]);