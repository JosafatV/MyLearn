angular.module('mod_MyLearn').controller('ctrl_crearCurso', ['srcv_cerrarSesion', 'fct_Trabajo', 'fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (srcv_cerrarSesion,fct_Trabajo, fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.profesorActual = {

        };
        $scope.creadoExitosamente = false;

        $scope.indexCursos = 0;
        $scope.sumaTotal = 0;
        $scope.ls_badges = [];
        $scope.ls_cursos = [];
        $scope.ls_listaUniversidades = [];

        /*
        * Service necesario para cerrar sesion
        */
        $scope.cerrarSesionService = srcv_cerrarSesion;

        /*
        *  Estructura del json necesario para crear una nueva cuenta
        *
        */

        $scope.js_crearCurso = {
            "IdProfesor": $routeParams.IdUser,
            "Nombre": "",
            "IdUniversidad": "",
            "NotaMinima": "",
            "FechaInicio": "",
            "NumeroGrupo": "",
            "Codigo" : "CE"

        };

        /*
        *  Estructura del json necesaria para crear un nuevo badge
        *
        */

        $scope.js_badgeActual = {
            "Nombre": "",
            "Puntaje": "",
            "IdCurso": ""
        };

        /*
        *  Solicitud a la base de datos para obtener las universidades 
        *  Necesaria para 
        *
        */


        fct_MyLearn_API_Client.query({ type: 'Universidades' }).$promise.then(function (data) {
            $scope.ls_listaUniversidades = data;
        });

        /*
        *  Solicitud a la base de datos para obtener la informacion del 
        * profesor que est� realizando la solicitud
        *
        */

        fct_MyLearn_API_Client.get({ type: 'Profesores', extension1: $routeParams.IdUser }).$promise.then(function (data) {
            $scope.profesorActual = data;
        });

        $scope.dp_crearCurso = function () {
            $scope.js_crearCurso.IdUniversidad = $scope.profesorActual.IdUniversidad;
            fct_MyLearn_API_Client.save({ type: 'CursosPorProfesor' }, $scope.js_crearCurso).$promise.then(function (data) {
                $scope.creadoExitosamente = true;
                angular.forEach($scope.ls_badges, function (value, key) {
                   value.IdCurso = data.idCurso
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
            $scope.js_badgeActual.Nombre = "";
            $scope.js_badgeActual.Puntaje = "";
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
            $scope.sumaTotal = parseInt($scope.sumaTotal) - parseInt($scope.ls_badges[index].Puntaje);
            $scope.ls_badges.splice(index,1);
            console.log($scope.sumaTotal);
        };

        $scope.goLogin = function () {
            $location.path('/MyLearn/Estudiante/Perfil/Login');
        };

    }]);
