angular.module('mod_MyLearn').controller('ctrl_areaTrabajoEstudianteProfesor', ['srcv_cerrarSesion', 'fileUpload', 'fct_UserJson', 'fct_Trabajo', 'fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (srcv_cerrarSesion, fileUpload, fct_UserJson, fct_Trabajo, fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.ls_msjs = [];
        $scope.ls_badges = [];
        $scope.enviandoMensaje = false;
        $scope.js_enviarMensaje = {
            Contenido: "",
            Adjunto: "",
            Fecha: "" ,
            NombreEmisor:""
        };
        
        /*
        * Service necesario para cerrar sesion
        */
        $scope.cerrarSesionService = srcv_cerrarSesion;

       $scope.userActual = {};

       get_messages();

       fct_MyLearn_API_Client.query({ type: 'Proyectos', extension1: 'Badges', extension2: $routeParams.IdTrabajo }).$promise.then(function (data) {
           $scope.ls_badges = data;
       });

       fct_MyLearn_API_Client.get({ type: 'Estudiantes', extension1: $routeParams.IdUser }).$promise.then(function (data) {
           $scope.userActual = data;
       });


        /*
        *  Funciones para llamar los mensajes totales del proyecto
        *
        */

       function get_messages() {
           fct_MyLearn_API_Client.query({ type: 'Mensajes', extension1: 'Proyecto', extension2: $routeParams.IdTrabajo }).$promise.then(function (data) {
               $scope.ls_msjs = data;
           });
       };

        /*
        * Funcion para enviar mensajes
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
                   $scope.myFile = null;
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
        * Funcion para enviar mensajes de respuesta
        */

       $scope.enviarMensajeResp = function () {
           var fileResp = $scope.myFileResp;
           $scope.enviandoMensaje = true;
           fileUpload.uploadFileToUrl(fileResp, $routeParams.IdUser).then(function (data) {
               var test2 = angular.fromJson(data);
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
        * Funcion para volver al perfil del estudiante
        */

       $scope.do_goPerfilEstudiante = function () {
           $location.path('/MyLearn/Estudiante/Perfil/' + $routeParams.IdUser);
       };

        /*
        * Funcion para abrir el campo de texto para responder mensajes
        */


       $scope.responder = function (mensaje) {
           console.log(mensaje);
           usuarioPrincipal = $scope.userActual;
           mensajeAGuardar = mensaje;
           modal = uibModal.open({
               animation: true,
               templateUrl: 'Vistas/Estudiante/ResponderMsj.html',
               controller: 'ctrl_areaTrabajoEstudianteProfesor',
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
        * Funcion para ver los badges del estudiante
        */

       $scope.verBadges = function () {
           usuarioPrincipal = $scope.userActual;
           mensajeAGuardar = mensaje;
           modal = uibModal.open({
               animation: true,
               templateUrl: 'Vistas/Estudiante/verBadgesEstudiante.html',
               controller: 'ctrl_areaTrabajoEstudianteProfesor',
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
        * Funcion usada para alardear Twits
        *
        */

       $scope.alardear = function (badge) {
           fct_MyLearn_API_Client.save({
               type: 'Twitt', extension1: 'Alardeo', extension2: $routeParams.IdUser,
               extension3: $scope.userActual.NombreContacto.trim(), extension4: badge.Id, extension5: badge.IdCurso, extension6: $routeParams.IdTrabajo
           }, {}).$promise.then(function (data) {
               fct_MyLearn_API_Client.query({ type: 'Proyectos', extension1: 'Badges', extension2: $routeParams.IdTrabajo }).$promise.then(function (data) {
                   $scope.ls_badges = data;
               });
           });
       };

        /*
        * Funcion para enviar mensajes usando Drive
        */

       function uploadFile(id){
           var file = $scope.myFile;

           console.log('file is ');
           console.dir(file);

           fileUpload.uploadFileToUrl(file, 32);
       };


        /*
        *
        *
        */


 }]);