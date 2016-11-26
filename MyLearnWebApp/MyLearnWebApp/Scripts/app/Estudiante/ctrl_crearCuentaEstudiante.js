angular.module('mod_MyLearn').controller('ctrl_crearCuentaEstudiante', ['$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService',
    function ($q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService) {

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
            Id: "",
            Contrasena: "",
            RepositorioArchivos: "",
            CredencialDrive: "",
            IdUniversidad: ""
        }

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

        $scope.do_agregueTec = function (tec) {
            $scope.ls_tecnologiasSelect.push(tec);
            $scope.ls_tecnologias.splice($scope.ls_tecnologias.indexOf(tec), 1);
        };

        $scope.goCrearCuenta = function () {
            $location.path("/MyLearn/CrearCuentaComo");
        };

    }]);