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

        $scope.js_badgeActual = {
            "Nombre": "",
            "Puntaje": "",
            "IdCurso": ""
        };

        $scope.sumaTotal = 0;

        fct_MyLearn_API_Client.query({ type: 'Universidades' }).$promise.then(function (data) {
            $scope.ls_listaUniversidades = data;
        });


        fct_MyLearn_API_Client.get({ type: 'Profesores', extension1: $routeParams.IdUser }).$promise.then(function (data) {
            $scope.profesorActual = data;
        });

        $scope.dp_crearCurso = function () {

            console.log($scope.js_crearCurso);
            fct_MyLearn_API_Client.save({ type: 'CursosPorProfesor' }, $scope.js_crearCurso).$promise.then(function (data) {

                angular.forEach($scope.ls_badges, function (value, key) {
                   value.IdCurso = data.idCurso
                    alert(angular.toJson(data));
                });

                fct_MyLearn_API_Client.save({ type: 'Cursos', extension1: 'Badges', extension2: data.IdCurso }, $scope.ls_badges).$promise.then(function (data) {
                    console.log(angular.toJson(data));
                });
            });
        };

        $scope.do_agregarBadge = function () {
            $scope.ls_badges.push({
                "Nombre":  $scope.js_badgeActual.Nombre,
                "Puntaje": $scope.js_badgeActual.Puntaje,
                "IdCurso": ""
            });
            $scope.sumaTotal = parseInt($scope.sumaTotal) + parseInt($scope.js_badgeActual.Puntaje);
            console.log($scope.sumaTotal);
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

        $scope.do_goPerfilEmpresa = function () {
            $location.path('/MyLearn/Profesor/Perfil/' + $routeParams.IdUser);
        };

        $scope.do_deleteBadge = function (index) {
            alert($scope.ls_badges[index].Puntaje);
            $scope.sumaTotal = parseInt($scope.sumaTotal) - parseInt($scope.ls_badges[index].Puntaje);
            $scope.ls_badges.splice(index,1);
            console.log($scope.sumaTotal);
        };

        $scope.goLogin = function () {
            $location.path('/MyLearn/Estudiante/Perfil/Login');
        };

    }]);
