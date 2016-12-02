angular.module('mod_MyLearn').controller('ctrl_perfilEmpresa', ['srcv_cerrarSesion', 'fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService',
    function (srcv_cerrarSesion,fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService) {

        $scope.num_indexTrabajos = 0;
        $scope.num_indexSubastas = 0;
        $scope.num_isNextPaginationSubastas = 0;
        $scope.num_isNextPaginationTrabajos = 0;

        var vm = this;

        /*
        * Service necesario para cerrar sesion
        */
        $scope.cerrarSesionService = srcv_cerrarSesion;

        fct_MyLearn_API_Client.get({ type: 'Empresas', extension1: $routeParams.IdUser }).$promise.then(function (data) {
            $scope.js_datosEmpresa = data;
        });

        fct_MyLearn_API_Client.query({ type: 'Trabajos', extension1: 'Empresa', extension2: $routeParams.IdUser, extension3: $scope.num_indexTrabajos }).$promise.then(function (data) {
            $scope.ls_trabajos = data;
        });

        fct_MyLearn_API_Client.query({ type: 'Subastas', extension1: 'Empresa', extension2: $routeParams.IdUser, extension3: $scope.num_indexSubastas }).$promise.then(function (data) {
            $scope.ls_subastas = data;
        });

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

        $scope.do_goCrearSubasta = function () {
            $location.path('/MyLearn/Empresa/CrearSubasta/' + $routeParams.IdUser);

        };

        $scope.get_20MoreWork = function () {
            $scope.num_indexTrabajos = $scope.num_indexTrabajos + 1;
            fct_MyLearn_API_Client.query({ type: 'Trabajos', extension1: 'Empresa', extension2: $routeParams.IdUser, extension3: $scope.num_indexTrabajos }).$promise.then(function (data) {
                $scope.ls_trabajos = data;

            });
        };

        $scope.get_20MoreSubastas = function () {
            $scope.num_indexSubastas = $scope.num_indexSubastas + 1;
            fct_MyLearn_API_Client.query({ type: 'Subastas', extension1: 'Empresa', extension2: $routeParams.IdUser, extension3: $scope.num_indexSubastas }).$promise.then(function (data) {
                $scope.ls_subastas = data;
            });
        };

        $scope.get_20LessSubasta = function () {
            $scope.num_indexSubastas = $scope.num_indexSubastas - 1;
            fct_MyLearn_API_Client.query({ type: 'Subastas', extension1: 'Empresa', extension2: $routeParams.IdUser, extension3: $scope.num_indexSubastas }).$promise.then(function (data) {
                $scope.ls_subastas = data;
            });
        };

        $scope.get_20LessWork = function () {
            $scope.num_indexTrabajos = $scope.num_indexTrabajos - 1;
            fct_MyLearn_API_Client.query({ type: 'Trabajos', extension1: 'Empresa', extension2: $routeParams.IdUser, extension3: $scope.num_indexTrabajos }).$promise.then(function (data) {
                $scope.ls_trabajos = data;
            });
        };

        $scope.do_goSubastas = function (subasta) {
            $location.path("/MyLearn/Empresa/Subasta/" + subasta.Id + "/" + subasta.IdEmpresa.trim() +  "/" + subasta.Nombre.trim() +  "/" + subasta.PresupuestoBase);
        };

        $scope.set_checkNextPaginationSubastas = function () {
            fct_MyLearn_API_Client.query({ type: 'Subastas', extension1: 'Empresa', extension2: $routeParams.IdUser, extension3: $scope.num_indexSubastas + 1 }).$promise.then(function (data) {
                $scope.num_isNextPaginationSubastas = data.lenght;
            });
        };

        $scope.set_checkNextPaginationTrabajos = function () {
            fct_MyLearn_API_Client.query({ type: 'Trabajos', extension1: 'Empresa', extension2: $routeParams.IdUser, extension3: $scope.num_indexTrabajos + 1 }).$promise.then(function (data) {
                $scope.num_isNextPaginationTrabajos = data.lenght;
            });
        };

        vm.do_goLogin = function () {

        };

        $scope.do_goTrabajos = function (trabajo) {
            $location.path('/MyLearn/Empresa/Perfil/AreaDeTrabajo/' + $routeParams.IdUser +"/"+ trabajo.IdTrabajo + "/" + trabajo.IdEstudiante);
        };
         $scope.do_goPerfil = function () {
            $location.path('/MyLearn/Empresa/Perfil/' + $routeParams.IdUser);
        };

    }]);