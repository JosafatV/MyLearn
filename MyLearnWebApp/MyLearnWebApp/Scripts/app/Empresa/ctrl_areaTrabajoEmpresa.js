angular.module('mod_MyLearn').controller('ctrl_areaTrabajoEmpresa', ['srcv_cerrarSesion', 'fileUpload', 'fct_UserJson', 'fct_Trabajo', 'fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (srcv_cerrarSesion,fileUpload, fct_UserJson, fct_Trabajo, fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.ls_msjs = [];
        $scope.starss = totStars;
        $scope.enviandoMensaje = false;
        $scope.js_enviarMensaje = {
            Contenido: "",
            Adjunto: "",
            Fecha: "" ,
            NombreEmisor:""
        };

        get_messages();

        /*
        * Service necesario para cerrar sesion
        */
        $scope.cerrarSesionService = srcv_cerrarSesion;

        $scope.trabajoActual = {};

        /*
        *  Usado para obtener la empresa actual
        *
        */

        fct_MyLearn_API_Client.get({ type: 'Empresas', extension1: $routeParams.IdUser }).$promise.then(function (data) {
            $scope.userActual = data;
        });


        /*
        *  Usado para obtener los datos del trabajo actual para ser mostrados
        */

       fct_MyLearn_API_Client.get({ type: 'Trabajos', extension1: $routeParams.IdTrabajo, extension2:$routeParams.IdEst.trim() }).$promise.then(function (data) {
           $scope.trabajoActual = data;
       });


        /*
        *  Funcion usada para obtener los mensajes del proyecto de empresa
        *
        */

       function get_messages() {

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
                   NombreEmisor: $scope.userActual.NombreEmpresarial
               }).$promise.then(function (data) {
                   $scope.myFile = null;
                   $scope.enviandoMensaje = false;
                   get_messages();
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
                   NombreEmisor: $scope.userActual.NombreEmpresarial,
                   MensajeRaiz: mensajeAGuardar.Id
               }).$promise.then(function () {
                   modal.close();
               });
           });
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
               controller: 'ctrl_areaTrabajoEmpresa',
               size: 'lg',
               backdrop: true,
               windowClass: 'center-modal',
           });
           modal.closed.then(function () {
               fct_MyLearn_API_Client.query({ type: 'Mensajes', extension1: 'Trabajo', extension2: $routeParams.IdTrabajo }).$promise.then(function (data) {
                   $scope.ls_msjs = data;
               });
           });

       };



        $scope.goSubastas = function () {
            $location.path('/MyLearn/Estudiante/Perfil/SubastaEstudiante');
        };


        $scope.goLogin = function () {
            $location.path('/MyLearn/Empresa/Perfil/Login');
        };

        $scope.do_goPerfilEmpresa = function () {
            $location.path('/MyLearn/Empresa/Perfil/' + $routeParams.IdUser);
        };


        $scope.terminarCalificar = function (stars) {
            ///alert('¿Desea Terminar y calificar con ' + stars + 'estrellas?');
            totStars = stars;
            modal = uibModal.open({
                animation: true,
                templateUrl: 'Vistas/Empresa/calificarProyecto.html',
                controller: 'ctrl_areaTrabajoEmpresa',
                size: 'sm',
                backdrop: true,
                windowClass: 'center-modal',
            });
            modal.closed.then(function () {
                fct_MyLearn_API_Client.query({ type: 'Mensajes', extension1: 'Trabajo', extension2: $routeParams.IdTrabajo }).$promise.then(function (data) {
                    $scope.ls_msjs = data;
                });
            });
        };

        $scope.set_exitoso = function () {
           exitoso = true;
        };

        $scope.set_fallido = function () {
           exitoso = false;
        };

        $scope.do_goCrearSubasta = function () {
            $location.path('/MyLearn/Empresa/CrearSubasta/' + $routeParams.IdUser);

        };


        $scope.sendCalificacion = function () {
            fct_MyLearn_API_Client.save({
                type: 'Trabajos', extension1: 'Terminados', extension2: $routeParams.IdTrabajo,
                extension3: $routeParams.IdEst.trim(), extension4: totStars, extension5: exitoso
            },{}).$promise.then(function (data) {
                $scope.ls_msjs = data;
                $scope.do_goPerfilEmpresa();
            });
        };

    }]);
var modal = "";
var exitoso = true;
var totStars = 5;