angular.module('mod_MyLearn').controller('ctrl_perfilEstudiante', ['fct_Trabajo', 'fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (fct_Trabajo, fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.js_datosEstudiante = {};
        $scope.ls_cursos = [];
        $scope.ls_trabajos = [];
        $scope.ls_estadisticas = [];
        $scope.ls_proyectos = [];


        fct_MyLearn_API_Client.get({ type: 'Estudiantes', extension1: $routeParams.IdUser }).$promise.then(function (data) {
            $scope.js_datosEstudiante = data;
        });

        fct_MyLearn_API_Client.query({ type: 'Trabajos', extension1: 'Estudiante', extension2: $routeParams.IdUser }).$promise.then(function (data) {
            $scope.ls_trabajos = data;
        });

        fct_MyLearn_API_Client.get({ type: 'Estudiantes', extension1: 'Estadisticas', extension2: $routeParams.IdUser }).$promise.then(function (data) {
            $scope.ls_estadisticas = data;
        });

        fct_MyLearn_API_Client.query({ type: 'Cursos', extension1: 'Estudiante', extension2: $routeParams.IdUser }).$promise.then(function (data) {
            $scope.ls_cursos = data;
        });

        fct_MyLearn_API_Client.query({ type: 'Proyectos', extension1: 'Estudiantes', extension2: $routeParams.IdUser }).$promise.then(function (data) {
            $scope.ls_proyectos = data;
        });

        $scope.do_goTrabajo = function (trabajo) {
            $location.path('/MyLearn/Estudiante/Perfil/AreaTrabajo/' + $routeParams.IdUser + "/" + trabajo.IdTrabajo);
        };

        $scope.do_goCurso = function (curso) { 
            $location.path('/MyLearn/Estudiante/Perfil/ProponerProyecto/' + $routeParams.IdUser + '/' + curso.Id);
        };

        $scope.do_goProyecto = function (proyecto) {
            $location.path('/MyLearn/Estudiante/Perfil/AreaTrabajoEstudianteProfesor/' + $routeParams.IdUser + '/' + proyecto.IdProyecto);
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
            $location.path('/MyLearn/Estudiante/Login');
        };
        $scope.do_goPerfil = function () {
            $location.path('/MyLearn/Estudiante/Perfil/' + $routeParams.IdUser);
        };

    }]);
