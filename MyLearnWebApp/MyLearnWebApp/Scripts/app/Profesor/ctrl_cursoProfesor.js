angular.module('mod_MyLearn').controller('ctrl_cursoProfesor', ['fct_Trabajo', 'fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (fct_Trabajo, fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.profesorActual = {};
        $scope.cursoActual = {};
        $scope.ls_badges = [];

        $scope.indexCursos = 0;

        fct_MyLearn_API_Client.get({ type: 'Profesores', extension1: $routeParams.IdUser }).$promise.then(function (data) {
            $scope.profesorActual = data;
        });

        fct_MyLearn_API_Client.get({ type: 'Cursos', extension1: $routeParams.IdCurso }).$promise.then(function (data) {
            $scope.cursoActual = data;
        });

        fct_MyLearn_API_Client.query({ type: 'Cursos', extension1:'Badges' , extension2: $routeParams.IdCurso }).$promise.then(function (data) {
            $scope.ls_badges = data;
        });

        $scope.goNotificaciones = function () {
            $location.path('/MyLearn/Profesor/Perfil');
        };

        $scope.do_goCrearCurso = function () {
            $location.path('/MyLearn/Profesor/Perfil/CrearCurso/' + $routeParams.IdUser);
        };

        $scope.do_goPerfil = function () {
            $location.path('/MyLearn/Profesor/Perfil/' + $routeParams.IdUser);
        };

        $scope.goLogin = function () {
            $location.path('/MyLearn/Estudiante/Perfil/Login');
        };

    }]);
