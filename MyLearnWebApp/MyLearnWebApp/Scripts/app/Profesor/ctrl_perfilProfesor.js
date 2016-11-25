angular.module('mod_MyLearn').controller('ctrl_perfilProfesor', ['fct_Trabajo', 'fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (fct_Trabajo, fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.profesorActual = {

        };
        $scope.ls_cursos = [];
       

        $scope.indexCursos = 0;


        fct_MyLearn_API_Client.get({ type: 'Profesores', extension1: $routeParams.IdUser }).$promise.then(function (data) {
            $scope.profesorActual = data;
        });

        fct_MyLearn_API_Client.query({ type: 'Cursos', extension1: 'Profesor', extension2: $routeParams.IdUser, extension3: $scope.indexCursos }).$promise.then(function (data) {
            $scope.ls_cursos = data;
        });

        $scope.do_goTrabajos = function (curso) {
            $location.path('/MyLearn/Profesor/Perfil/AreaDeTrabajo/' + $routeParams.IdUser.trim() + "/" + curso.IdCurso);
        };

        $scope.goNotificaciones = function () {
            $location.path('/MyLearn/Profesor/Perfil');
        };

        $scope.do_goCrearCurso = function () {
            $location.path('/MyLearn/Profesor/Perfil/CrearCurso/' + $routeParams.IdUser);
        };

        $scope.do_goCurso = function (curso) {
            console.log(curso);
            $location.path('/MyLearn/Profesor/Perfil/CursoProfesor/' + $routeParams.IdUser + '/' + curso.IdCurso);

        };

        $scope.goLogin = function () {
            $location.path('/MyLearn/Estudiante/Perfil/Login');
        };

    }]);
