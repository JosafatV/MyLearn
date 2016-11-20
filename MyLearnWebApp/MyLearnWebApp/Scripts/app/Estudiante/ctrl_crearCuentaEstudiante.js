angular.module('mod_MyLearn').controller('ctrl_crearCuentaEstudiante', ['$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService',
    function ($q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService) {


        $scope.str_paisSelected = "";

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
            Id: "",
            Contrasena: "",
            RepositorioArchivos: "",
            CredencialDrive: "",
        }

        fct_MyLearn_API_Client.query({ type: 'Paises' }).$promise.then(function (data) {
            $scope.lst_listaPaises = data;
        });

        $scope.sendCuenta = function () {
            alert(angular.toJson($scope.js_crearCuentaJson));
            fct_MyLearn_API_Client.save({ type: 'Estudiantes' }, $scope.js_crearCuentaJson).$promise.then(function (data) {
                alert(angular.toJson(data));
            });
        }

        $scope.goCrearCuenta = function () {
            $location.path("/MyLearn/Estudiante/CrearCuenta");
        };

    }]);