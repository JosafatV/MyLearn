angular.module('mod_MyLearn').controller('ctrl_areaTrabajoProfesor', ['fct_Trabajo', 'fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (fct_Trabajo, fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.ls_msjs = [];

        console.log(angular.toJson(fct_Trabajo.get_trabajo()));
        fct_MyLearn_API_Client.query({ type: 'Mensajes', extension1: 'Trabajo', extension2: fct_Trabajo.get_trabajo().IdTrabajo }).$promise.then(function (data) {
            console.log(angular.toJson(data));
            $scope.ls_msjs = data;
        });

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
