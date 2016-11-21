angular.module('mod_MyLearn').controller('ctrl_perfilEmpresa', ['fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService',
    function (fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService) {

        var num_indexTrabajos = 0;
        var num_indexSubastas = 0;

        var vm = this;

        fct_MyLearn_API_Client.get({ type: 'Empresas', extension1: fct_User.getId() }).$promise.then(function (data) {
            $scope.js_datosEmpresa = data;
        });

        fct_MyLearn_API_Client.query({ type: 'Trabajos', extension1: 'Empresa', extension2: fct_User.getId(), extension3: num_indexTrabajos }).$promise.then(function (data) {
            $scope.ls_trabajos = data;
        });

        fct_MyLearn_API_Client.query({ type: 'Subastas', extension1: 'Empresa', extension2: fct_User.getId(), extension3: num_indexSubastas }).$promise.then(function (data) {
            alert(angular.toJson(data, true));
            $scope.ls_subastas = data;
        });

        //alert($routeParams.id);

        fct_MyLearn_API_Client.query({ type: 'Paises' }).$promise.then(function (data) {
            vm.ls_listaPaises = data;
        });

        fct_MyLearn_API_Client.query({ type: 'Paises' }).$promise.then(function (data) {
            vm.ls_listaPaises = data;
        });

        vm.sumarContador = function () {
            index = index + 1;
        };

        vm.restarContador = function () {
            index = index - 1;
        };

        vm.changePais = function () {
            vm.js_crearCuenta.Pais = vm.paisSelected.Pais1;
        };

        vm.set_sendCuenta = function () {            

        }

        vm.do_goCrearSubasta = function () {
            $location.path('/MyLearn/Empresa/Perfil/');

        };

        vm.do_goLogin = function () {


        };

    }]);