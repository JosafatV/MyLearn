angular.module('mod_MyLearn').controller('ctrl_perfilEstudiante', ['fct_Trabajo', 'fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (fct_Trabajo,fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {


        fct_MyLearn_API_Client.query({ type: 'Trabajos', extension1: 'Estudiante', extension2: $routeParams.IdUser }).$promise.then(function (data) {
            $scope.ls_trabajos = data;
        });

        $scope.do_goTrabajo = function (trabajo) {
            $location.path('/MyLearn/Estudiante/Perfil/AreaTrabajo/' + $routeParams.IdUser + "/" + trabajo.IdTrabajo);
        };

        $scope.goCursosDisponibles = function () {
            $location.path('/MyLearn/Estudiante/Perfil/' + $routeParams.IdUser + '/CursosDisponibles');
        };

        $scope.goSubastas = function () {
            $location.path('/MyLearn/Estudiante/Perfil/'+$routeParams.IdUser+'/SubastaEstudiante');
        };

        $scope.goNotificaciones = function () {
            $location.path('/MyLearn/Estudiante/Perfil');
        };

        $scope.goLogin = function () {
            $location.path('/MyLearn/Estudiante/Perfil/Login');
        };

    }]);
