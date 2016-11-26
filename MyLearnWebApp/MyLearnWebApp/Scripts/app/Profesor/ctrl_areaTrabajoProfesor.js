angular.module('mod_MyLearn').controller('ctrl_areaTrabajoProfesor', ['fct_Trabajo', 'fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (fct_Trabajo, fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.ls_msjs = [];

        $scope.userActual = {};

        get_badgesObtenidos();

        get_badgesNoOtorgados();

        get_trabajoActual();

        $scope.envioExitoso = false;

        $scope.envioFallido = false;

       fct_MyLearn_API_Client.query({ type: 'Mensajes', extension1: 'Proyecto', extension2: $routeParams.IdTrabajo }).$promise.then(function (data) {
            $scope.ls_msjs = data;
       });

       fct_MyLearn_API_Client.query({ type: 'Proyectos', extension1: 'Badges', extension2: $routeParams.IdTrabajo }).$promise.then(function (data) {
           $scope.ls_badgesObtenidos = data;
       }); 

       fct_MyLearn_API_Client.get({ type: 'Profesores', extension1: $routeParams.IdUser }).$promise.then(function (data) {
           $scope.userActual = data;
       });



       fct_MyLearn_API_Client.query({ type: 'Trabajos', extension1: 'Tecnologias' ,extension2: $routeParams.IdTrabajo.trim()}).$promise.then(function (data) {
           $scope.ls_tec = data;
       });

       function get_trabajoActual() {
           fct_MyLearn_API_Client.get({ type: 'Proyectos', extension1: 'Curso', extension2: $routeParams.IdTrabajo.trim() }).$promise.then(function (data) {
               $scope.trabajoActual = data;
           });
       };

       function get_badgesNoOtorgados() {
           fct_MyLearn_API_Client.query({ type: 'Proyectos', extension1: 'BadgesNoOtorgados', extension2: $routeParams.IdCurso, extension3: $routeParams.IdTrabajo }).$promise.then(function (data) {
               $scope.ls_badgesSA = data;
           });
       };

       function get_badgesObtenidos() {
           fct_MyLearn_API_Client.query({ type: 'Proyectos', extension1: 'Badges', extension2: $routeParams.IdTrabajo }).$promise.then(function (data) {
               $scope.ls_badgesObtenidos = data;
           });
       };


        $scope.enviarMensaje = function () {
            fct_MyLearn_API_Client.save({ type: 'Mensajes', extension1: 'Proyecto', extension2: $routeParams.IdTrabajo }, {
                Contenido: $scope.js_enviarMensaje.Contenido, Adjunto: $scope.js_enviarMensaje.Adjunto, NombreEmisor: $scope.userActual.NombreContacto
            }).$promise.then(function (data) {
                fct_MyLearn_API_Client.query({ type: 'Mensajes', extension1: 'Proyecto', extension2: $routeParams.IdTrabajo }).$promise.then(function (data) {
                    $scope.ls_msjs = data;
                    $scope.js_enviarMensaje.Contenido = "";
                });
            });
        };

        $scope.enviarMensajeResp = function () {
            fct_MyLearn_API_Client.save({ type: 'Mensajes', extension1: 'Proyecto', extension2: 'Respuesta' }, {
                Contenido: $scope.js_enviarMensaje.Contenido, Adjunto: $scope.js_enviarMensaje.Adjunto, NombreEmisor: $scope.userActual.NombreContacto,
                MensajeRaiz: mensajeAGuardar.Id
            }).$promise.then(function () {
                modal.close();
            });

        };

        $scope.do_goPerfilProfesor = function () {
            $location.path('/MyLearn/Profesor/Perfil/' + $routeParams.IdUser);
        };


        $scope.otorgarBadge = function (badge) {
            fct_MyLearn_API_Client.save({ type: 'Proyectos', extension1: 'Badge' }, {
                IdBadge: badge.Id,
                IdProyecto: $routeParams.IdTrabajo
            }).$promise.then(function (data) {
                $scope.publicadoExitosamente = true;
                $scope.publicadoErroneamente = false;
                get_badgesNoOtorgados();                
            }, function (error) {
                $scope.publicadoExitosamente = false;
                $scope.publicadoErroneamente = true;
            });
        };

        $scope.asignarBadges = function () {
            usuarioPrincipal = $scope.userActual;
            mensajeAGuardar = mensaje;
            modal = uibModal.open({
                animation: true,
                templateUrl: 'Vistas/Estudiante/asignarBadgesProfesor.html',
                controller: 'ctrl_areaTrabajoProfesor',
                size: 'lg',
                backdrop: true,
                windowClass: 'center-modal',
            });
            modal.closed.then(function () {
                get_trabajoActual();
                get_badgesObtenidos();
                fct_MyLearn_API_Client.query({ type: 'Mensajes', extension1: 'Proyecto', extension2: $routeParams.IdTrabajo }).$promise.then(function (data) {
                    $scope.ls_msjs = data;
                });
            });

        };

        $scope.responder = function (mensaje) {
            console.log(mensaje);
            usuarioPrincipal = $scope.userActual;
            mensajeAGuardar = mensaje;
            modal = uibModal.open({
                animation: true,
                templateUrl: 'Vistas/Estudiante/ResponderMsj.html',
                controller: 'ctrl_areaTrabajoProfesor',
                size: 'lg',
                backdrop: true,
                windowClass: 'center-modal',
            });
            modal.closed.then(function () {
                fct_MyLearn_API_Client.query({ type: 'Mensajes', extension1: 'Proyecto', extension2: $routeParams.IdTrabajo }).$promise.then(function (data) {
                    $scope.ls_msjs = data;
                });
            });

        };

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
