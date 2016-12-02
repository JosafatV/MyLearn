angular.module('mod_MyLearn').controller('ctrl_responderMensaje', ['srcv_cerrarSesion', 'fct_UserJson', 'fct_Trabajo', 'fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (srcv_cerrarSesion,fct_UserJson, fct_Trabajo, fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.ls_msjs = [];

        $scope.js_enviarMensaje = usuarioPrincipal;

        fct_MyLearn_API_Client.get({ type: 'Estudiantes', extension1: $routeParams.IdUser }).$promise.then(function (data) {
            $scope.userActual = data;
        });

        $scope.enviarMensajeResp = function () {
            fct_MyLearn_API_Client.save({ type: 'Mensajes', extension1: 'Trabajo', extension2:'Respuesta'}, {
                Contenido: $scope.js_enviarMensaje.Contenido, Adjunto: $scope.js_enviarMensaje.Adjunto, NombreEmisor: $scope.userActual.NombreContacto,
                MensajeRaiz: mensajeAGuardar.Id
            })
        };

    }]);
