var str_id = 13;
angular.module('mod_MyLearn').controller('ctrl_crearCuentaComo', ['fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {
   

        $scope.goCrearCuentaProfesor = function () {
            $location.path('/MyLearn/Profesor/CrearCuenta');
        };

        $scope.goCrearCuentaEmpresa = function () {
            $location.path("/MyLearn/Empresa/CrearCuenta");
        };

        $scope.do_goCrearCuentaEstudiante = function () {
            $location.path('/MyLearn/Estudiante/CrearCuenta');
        };

    }]);
