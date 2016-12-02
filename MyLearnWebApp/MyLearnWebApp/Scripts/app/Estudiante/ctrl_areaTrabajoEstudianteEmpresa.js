var modal = "";
angular.module('mod_MyLearn').controller('ctrl_areaTrabajoEstudianteEmpresa', ['fileUpload', 'fct_UserJson', 'fct_Trabajo', 'fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (fileUpload, fct_UserJson,fct_Trabajo, fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.ls_msjs = [];

        

        $scope.js_enviarMensaje = {
            Contenido: "",
            Adjunto: "",
            Fecha: "" ,
            NombreEmisor:""
        };

        $scope.userActual = {};

        get_mensajes();



       fct_MyLearn_API_Client.get({ type: 'Estudiantes', extension1: $routeParams.IdUser }).$promise.then(function (data) {
           $scope.userActual = data;
       });

       function get_mensajes() {
           fct_MyLearn_API_Client.query({ type: 'Mensajes', extension1: 'Trabajo', extension2: $routeParams.IdTrabajo }).$promise.then(function (data) {
               $scope.ls_msjs = data;
           });
       };
        /*
        * Funcion para enviar mensajes
        *
        */

       $scope.enviarMensaje = function () {
           var file = $scope.myFile;
           $scope.enviandoMensaje = true;
           fileUpload.uploadFileToUrl(file, $routeParams.IdUser).then(function (data) {
               var test = angular.fromJson(data);
               fct_MyLearn_API_Client.save({ type: 'Mensajes', extension1: 'Trabajo', extension2: $routeParams.IdTrabajo }, {
                   Contenido: $scope.js_enviarMensaje.Contenido, Adjunto: test.link,
                   NombreEmisor: $scope.userActual.NombreContacto
               }).$promise.then(function (data) {
                   $scope.myFile = null;
                   $scope.enviandoMensaje = false;
                   get_mensajes();
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
               fct_MyLearn_API_Client.save({ type: 'Mensajes', extension1: 'Trabajo', extension2: 'Respuesta' }, {
                   Contenido: $scope.js_enviarMensaje.Contenido, Adjunto: test2.link,
                   NombreEmisor: $scope.userActual.NombreContacto,
                   MensajeRaiz: mensajeAGuardar.Id
               }).$promise.then(function () {
                   modal.close();
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
               controller: 'ctrl_areaTrabajoEstudianteEmpresa',
               size: 'lg',
               backdrop: true,
               windowClass: 'center-modal',
           });
           modal.closed.then(function () {
               get_mensajes();
           });

       };


       $scope.do_goPerfilEstudiante = function () {
           $location.path('/MyLearn/Estudiante/Perfil/' + $routeParams.IdUser);
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
























