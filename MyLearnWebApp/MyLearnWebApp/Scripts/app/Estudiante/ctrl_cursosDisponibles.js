angular.module('mod_MyLearn').controller('ctrl_cursosDisponibles', ['$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function ($q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.js_estudianteActual = {};
        $scope.js_cursosUniversidad = {};
        $scope.js_incluirCurso =
        {
            "IdEstudiante": "",
            "IdCurso": "",
        };

        fct_MyLearn_API_Client.get({ type: 'Estudiantes', extension1: $routeParams.IdUser}).$promise.then(function (data) {
            $scope.js_estudianteActual = data;
            $scope.js_incluirCurso.IdEstudiante = $routeParams.IdUser;
            fct_MyLearn_API_Client.query({
                type: 'Cursos', extension1: 'Universidad', extension2: $scope.js_estudianteActual.IdUniversidad,
                                                extension3:$routeParams.IdUser}).$promise.then(function (data) {
                $scope.js_cursosUniversidad = data;
            });
        });


        $scope.do_incluirme = function (curso) {
            console.log(curso.Id);
            fct_MyLearn_API_Client.save({ type: 'Estudiantes', extension1: 'Curso' },        {
                "IdEstudiante": $routeParams.IdUser,
                "IdCurso": curso.Id,
            }).$promise.then(function (data) {
                console.log(angular.toJson(data));
            });
        };

        $scope.do_goPerfil = function () {
            $location.path('/MyLearn/Estudiante/Perfil/' + $routeParams.IdUser);
        };



    }]);
