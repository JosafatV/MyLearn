angular.module('mod_MyLearn').controller('ctrl_login', ['$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function ($q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.goCrearCuenta = function () {
            $location.path("/MyLearn/Estudiante/CrearCuenta");
        };

        $scope.goPerfil = function () {
            $location.path('/MyLearn/Estudiante/Perfil');
        };

        $scope.testModal = function () {
            uibModal.open({
                animation: true,
                templateUrl: 'Vistas/Estudiante/Perfil_Estudiante.html',
                controller: 'ctrl_login',
                size: 'lg'
            })
        };

    }]);
