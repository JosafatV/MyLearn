angular.module('mod_MyLearn').controller('ctrl_login', ['$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function ($q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.goCrearCuentaEstudiante = function () {
            $location.path("/MyLearn/Estudiante/CrearCuenta");
        };

        $scope.goCrearProfesor = function () {
            $location.path("/MyLearn/Profesor/CrearCuenta");
        };

        $scope.goCrearCuentaEmpresa = function () {
            $location.path("/MyLearn/Empresa/CrearCuenta");
        };

        $scope.goPerfil = function () {
            alert($scope.usuario);
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
