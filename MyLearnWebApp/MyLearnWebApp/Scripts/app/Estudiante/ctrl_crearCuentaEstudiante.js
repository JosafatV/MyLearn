angular.module('mod_MyLearn').controller('ctrl_crearCuentaEstudiante', ['$q','$scope', '$routeParams', '$location', 'ModalService', 'waveWebApiResource', 'twitterService',
    function ($q, $scope, $routeParams, $location, ModalService, waveWebApiResource, twitterService) {

        $scope.goCrearCuenta = function () {
            $location.path("/MyLearn/Estudiante/CrearCuenta");
        };

    }]);