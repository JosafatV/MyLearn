angular.module('mod_MyLearn').controller('ctrl_crearCuentaProfesor', ['$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService',
    function ($q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService) {



        $scope.crearCuentaJson =
           {
               "Id": "",
               "Contrasena": "",
               "Sal": "",
               "RepositorioArchivos": "",
               "CredencialDrive": "",
               "Estado": "",
               "NombreContacto": "",
               "ApellidoContacto": "",
               "Email": "",
               "Telefono": "",
               "Foto": null,
               //"FechaInscripcion": "2016-11-15T00:00:00",
               "Pais": "",
               "HorarioAtencion": "",
               "Region": "",
               "IdUniversidad": 2,
               "Universidad": "Universidad Nacional          "
           }

        $scope.paisSelected = "";
        $scope.usuario = "";
        $scope.contrasenia = "";


        fct_MyLearn_API_Client.query({ type: 'Paises' }).$promise.then(function (data) {
            $scope.listaPaises = data;
        });


        $scope.changePais = function () {
            $scope.crearCuentaJson.Pais = $scope.paisSelected.Pais1;
        };

        $scope.goCrearCuenta = function () {
            $location.path("/MyLearn/Estudiante/CrearCuenta");
        };

        $scope.sendCuenta = function () {
            alert(angular.toJson($scope.crearCuentaJson));
            fct_MyLearn_API_Client.save({ type: 'Profesores' }, $scope.crearCuentaJson);

        }

    }]);