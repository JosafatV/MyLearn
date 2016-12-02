angular.module('mod_MyLearn').controller('ctrl_areaTrabajoProfesor', ['fct_Trabajo', 'fileUpload', 'fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (fct_Trabajo, fileUpload, fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.ls_msjs = [];

        $scope.userActual = {};

        /*
        *  Se llaman la funcion para obtener la lista de los badges obtenidos
        *
        */

        get_badgesObtenidos();

        /*
        *  Se llaman la funcion para obtener la lista de los badges no otorgados
        *
        */

        get_badgesNoOtorgados();

        /*
        *  Se llaman la funcion para obtener el id del trabajo actual
        *
        */

        get_trabajoActual();

        /*
        *  Se llaman la funcion para obtener los mensajes
        *
        */

        get_messages()

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

        /*
        *  Funcion para obtener los mensajes de la lista
        *
        */

       function get_messages() {
           fct_MyLearn_API_Client.query({ type: 'Mensajes', extension1: 'Proyecto', extension2: $routeParams.IdTrabajo }).$promise.then(function (data) {
               $scope.ls_msjs = data;
           });
       };


        /*
        *   Esta es la funcion que se encarga de solicitar el trabajo actual al API 
        *
        */

       function get_trabajoActual() {
           fct_MyLearn_API_Client.get({ type: 'Proyectos', extension1: 'Curso', extension2: $routeParams.IdTrabajo.trim() }).$promise.then(function (data) {
               $scope.trabajoActual = data;
           });
       };

        /*
        *   Esta es la funcion que se encarga de solicitar los badges no otorgados al API 
        *
        */

       function get_badgesNoOtorgados() {
           fct_MyLearn_API_Client.query({ type: 'Proyectos', extension1: 'BadgesNoOtorgados', extension2: $routeParams.IdCurso, extension3: $routeParams.IdTrabajo }).$promise.then(function (data) {
               $scope.ls_badgesSA = data;
           });
       };

        /*
        *   Esta es la funcion que se encarga de solicitar los badges obtenidos al API 
        *
        */

       function get_badgesObtenidos() {
           fct_MyLearn_API_Client.query({ type: 'Proyectos', extension1: 'Badges', extension2: $routeParams.IdTrabajo }).$promise.then(function (data) {
               $scope.ls_badgesObtenidos = data;
           });
       };

        /*
        *   Esta es la funcion que se encarga de enviar un nuevo mensaje del usuario 
        *   Luego de eso realiza otra llamada para solicitar que los mensajes sean actualizados
        *
        */

       $scope.enviarMensaje = function () {
           var file = $scope.myFile;
           $scope.enviandoMensaje = true;
           fileUpload.uploadFileToUrl(file, $routeParams.IdUser).then(function (data) {
               var test = angular.fromJson(data);
               fct_MyLearn_API_Client.save({ type: 'Mensajes', extension1: 'Proyecto', extension2: $routeParams.IdTrabajo }, {
                   Contenido: $scope.js_enviarMensaje.Contenido, Adjunto: $scope.js_enviarMensaje.Adjunto,
                   NombreEmisor: $scope.userActual.NombreContacto, Adjunto: test.link
               }).$promise.then(function (data) {
                   get_messages();
                   $scope.enviandoMensaje = false;
                   $scope.js_enviarMensaje = {
                       Contenido: "",
                       Adjunto: "",
                       Fecha: "",
                       NombreEmisor: ""
                   };
               });
           });
       };

        /*
        * Esta es la funcion encargada de enviar la respuesta de un mensaje al API para almacenarlo
        *
        */

       $scope.enviarMensajeResp = function () {
           var fileResp = $scope.myFileResp;
           $scope.enviandoMensaje = true;
           fileUpload.uploadFileToUrl(fileResp, $routeParams.IdUser).then(function (data) {
               var test2 = angular.fromJson(data);
               console.log(test2);
               console.log(test2);
               fct_MyLearn_API_Client.save({ type: 'Mensajes', extension1: 'Proyecto', extension2: 'Respuesta' }, {
                   Contenido: $scope.js_enviarMensaje.Contenido, Adjunto: test2.link, NombreEmisor: $scope.userActual.NombreContacto,
                   MensajeRaiz: mensajeAGuardar.Id
               }).$promise.then(function () {
                   $scope.enviandoMensaje = false;
                   modal.close();
               });
           });

       };

        /*
        *  Esta es la funcion encargada mostrar los badges que pueden ser asignados al estudiante por parte del profesor
        *
        */

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

        /*
        *  Esta es la funcion encargada de desplegar la pantalla donde se pueden ver los badge
        *  a otorgar
        *
        */

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

        /*
        *  Esta es la función encargada de abrir la vista para enviar la respuesta de un mensaje
        *
        */ 

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

        /*
        * Esta es la función encardada de terminar un proyecto
        *
        */

        $scope.do_terminarProyecto = function () {
            fct_MyLearn_API_Client.save({ type: 'ProyectosTerminados', extension1: $routeParams.IdTrabajo, extension2: $routeParams.IdEst }, {}).$promise.then(function (data) {
                $scope.do_goCurso();
            });
        };


        /*
        * Estas son las funciones encargadas de ir a las diferentes vistas
        *
        */

        $scope.do_goCurso = function () {
            $location.path('/MyLearn/Profesor/Perfil/CursoProfesor/' + $routeParams.IdUser + '/' + $routeParams.IdCurso);

        };

        $scope.do_goPerfilProfesor = function () {
            $location.path('/MyLearn/Profesor/Perfil/' + $routeParams.IdUser);
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
