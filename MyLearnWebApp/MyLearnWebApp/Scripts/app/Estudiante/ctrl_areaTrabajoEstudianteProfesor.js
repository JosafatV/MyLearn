angular.module('mod_MyLearn').controller('ctrl_areaTrabajoEstudianteProfesor', ['fct_UserJson', 'fct_Trabajo', 'fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (fct_UserJson,fct_Trabajo, fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.ls_msjs = [];
        $scope.ls_badges = [];

        $scope.js_enviarMensaje = {
            Contenido: "",
            Adjunto: "",
            Fecha: "" ,
            NombreEmisor:""
        };

       $scope.userActual = {};

       fct_MyLearn_API_Client.query({ type: 'Mensajes', extension1: 'Proyecto', extension2: $routeParams.IdTrabajo }).$promise.then(function (data) {
            $scope.ls_msjs = data;
       });

       fct_MyLearn_API_Client.query({ type: 'Proyectos', extension1: 'Badges', extension2: $routeParams.IdTrabajo }).$promise.then(function (data) {
           $scope.ls_badges = data;
       });

       fct_MyLearn_API_Client.get({ type: 'Estudiantes', extension1: $routeParams.IdUser }).$promise.then(function (data) {
           $scope.userActual = data;
       });

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
    * Funcion para enviar mensajes usando Drive
    */

 }]);