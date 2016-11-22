angular.module('mod_MyLearn').controller('ctrl_crearCurso', ['fct_Trabajo', 'fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (fct_Trabajo, fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.profesorActual = {

        };

        $scope.indexCursos = 0;

        $scope.ls_badges = [];
        $scope.ls_cursos = [];
        $scope.ls_listaUniversidades = [];

        $scope.js_crearCurso = {
            "IdProfesor": $routeParams.IdUser,
            "Nombre": "",
            "IdUniversidad": "",
            "NotaMinima": "",
            "FechaInicio": "",
            "NumeroGrupo": ""

        };


        fct_MyLearn_API_Client.query({ type: 'Universidades' }).$promise.then(function (data) {
            $scope.ls_listaUniversidades = data;
        });


        fct_MyLearn_API_Client.get({ type: 'Profesores', extension1: $routeParams.IdUser }).$promise.then(function (data) {
            $scope.profesorActual = data;
        });

        $scope.dp_crearCurso = function () {

            console.log($scope.js_crearCurso);
            fct_MyLearn_API_Client.save({ type: 'CursosPorProfesor' }, $scope.js_crearCurso).$promise.then(function (data) {
                alert(angular.toJson(data));
            });
        };

        $scope.changeUniversidad = function () {
            $scope.js_crearCurso.IdUniversidad = $scope.universidadSelected.Id;
        };

        $scope.alerte = function () {
            console.log($scope.js_crearCurso);
        };

        $scope.goNotificaciones = function () {
            $location.path('/MyLearn/Profesor/Perfil');
        };

        $scope.goLogin = function () {
            $location.path('/MyLearn/Estudiante/Perfil/Login');
        };

    }]);
