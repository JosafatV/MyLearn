angular.module('mod_MyLearn').controller('ctrl_cursoProfesor', ['srcv_cerrarSesion', 'fct_Trabajo', 'fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (srcv_cerrarSesion,fct_Trabajo, fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.profesorActual = {};
        $scope.cursoActual = {};
        $scope.ls_badges = [];
        $scope.ls_estudiantes = [];

        $scope.indexCursos = 0;

        /*
        * Service necesario para cerrar sesion
        */
        $scope.cerrarSesionService = srcv_cerrarSesion;

        fct_MyLearn_API_Client.get({ type: 'Profesores', extension1: $routeParams.IdUser }).$promise.then(function (data) {
            $scope.profesorActual = data;
        });

        fct_MyLearn_API_Client.query({ type: 'Proyectos', extension1: 'Profesores', extension2: 'Curso', extension3: $routeParams.IdCurso }).$promise.then(function (data) {
            $scope.ls_estudiantes = data;
        });

        fct_MyLearn_API_Client.get({ type: 'Cursos', extension1: $routeParams.IdCurso }).$promise.then(function (data) {
            $scope.cursoActual = data;
        });

        fct_MyLearn_API_Client.query({ type: 'Cursos', extension1:'Badges' , extension2: $routeParams.IdCurso }).$promise.then(function (data) {
            $scope.ls_badges = data;
        });

        $scope.terminarCurso = function () {
            fct_MyLearn_API_Client.get({ type: 'Cursos', extension1: 'Terminado', extension2: $routeParams.IdCurso }, {}).$promise.then(function (data) {
                //SSSSss$scope.ls_badges = data;
            });
        };

        $scope.go_verProyecto = function (proyecto) {
            $location.path('/MyLearn/Estudiante/Perfil/AreaTrabajoProfesor/' + $routeParams.IdUser + '/' +
                    proyecto.IdProyecto + '/' + proyecto.IdEstudiante.trim()+ '/' + $routeParams.IdCurso);
        };

        $scope.go_verProyectoTerminado = function (proyecto) {
            $location.path('/MyLearn/Estudiante/Perfil/AreaTrabajoProfesorLectura/' + $routeParams.IdUser + '/' +
                    proyecto.IdProyecto + '/' + proyecto.IdEstudiante.trim() + '/' + $routeParams.IdCurso);
        };

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
        $scope.do_goCrearCurso = function () {
            $location.path('/MyLearn/Profesor/Perfil/CrearCurso/' + $routeParams.IdUser);
        };

    }]);
