angular.module('mod_MyLearn').controller('ctrl_perfilEstudiante', ['fct_Trabajo', 'fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (fct_Trabajo,fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {


        fct_MyLearn_API_Client.query({ type: 'Trabajos', extension1: 'Estudiante', extension2: fct_User.getId() }).$promise.then(function (data) {
            $scope.ls_trabajos = data;
        });

        $scope.do_goTrabajo = function (trabajo) {
            fct_Trabajo.set_trabajo(trabajo);
            $location.path('/MyLearn/Estudiante/Perfil/AreaTrabajo');
        };

        $scope.goCursosDisponibles = function () {
            $location.path('/MyLearn/Estudiante/Perfil/CursosDisponibles');
        };

        $scope.goSubastas = function () {
            $location.path('/MyLearn/Estudiante/Perfil/SubastaEstudiante');
        };

        $scope.goNotificaciones = function () {
            $location.path('/MyLearn/Estudiante/Perfil');
        };

        $scope.goLogin = function () {
            $location.path('/MyLearn/Estudiante/Perfil/Login');
        };

    }]);
