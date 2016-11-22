angular.module('mod_MyLearn').controller('ctrl_perfilProfesor', ['fct_Trabajo', 'fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (fct_Trabajo, fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.profesorActual = {

        };

        fct_MyLearn_API_Client.query({ type: 'Profesores', extension: $routeParams.IdUser }).$promise.then(function (data) {
            $scope.profesorActual = data[0];
        });

        $scope.do_goTrabajo = function (trabajo) {
            fct_Trabajo.set_trabajo(trabajo);
            $location.path('/MyLearn/Estudiante/Perfil/AreaTrabajo');
        };

        $scope.goNotificaciones = function () {
            $location.path('/MyLearn/Estudiante/Perfil');
        };

        $scope.crearCurso = function () {

        };

        $scope.goLogin = function () {
            $location.path('/MyLearn/Estudiante/Perfil/Login');
        };

    }]);
