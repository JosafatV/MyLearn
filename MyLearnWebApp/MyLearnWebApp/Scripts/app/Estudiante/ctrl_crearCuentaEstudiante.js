angular.module('mod_MyLearn').controller('ctrl_crearCuentaEstudiante', ['$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService',
    function ($q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService) {


        $scope.str_paisSelected = "";
        $scope.ls_tecnologiasSelect = [];

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

        fct_MyLearn_API_Client.query({ type: 'Tecnologias' }).$promise.then(function (data) {
            $scope.ls_tecnologias = data;
        });

        $scope.alertePrueba = function () {
            alert("hola");
        };

        $scope.changePais = function () {
            $scope.js_crearCuentaJson.Pais = $scope.paisSelected.Pais1;
        };

        $scope.sendCuenta = function () {
            fct_MyLearn_API_Client.save({ type: 'Estudiantes' }, $scope.js_crearCuentaJson).$promise.then(function (data) {
                alert(angular.toJson(data));
            });
        }

        $scope.goCrearCuenta = function () {
            $location.path("/MyLearn/Estudiante/CrearCuenta");
        };

    }]);