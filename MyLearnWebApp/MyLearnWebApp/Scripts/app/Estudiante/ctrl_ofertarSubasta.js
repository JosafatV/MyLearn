angular.module('mod_MyLearn').controller('ctrl_ofertarSubasta', ['$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function ($q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.js_datosEstudiante = {};
        $scope.ls_otrasSubastas = [];

        fct_MyLearn_API_Client.get({ type: 'Estudiantes', extension1: $routeParams.IdUser }).$promise.then(function (data) {
            $scope.js_datosEstudiante = data;
        });

        fct_MyLearn_API_Client.query({
            type: 'Subastas', extension1: 'Ofertas', extension2: $routeParams.IdUser
                        , extension3: $routeParams.IdSub}).$promise.then(function (data) {
            console.log(angular.toJson(data));
            $scope.ls_otrasSubastas = data;
        });

        $scope.do_goPerfilEstudiante = function () {
            $location.path('/MyLearn/Estudiante/Perfil/' + $routeParams.IdUser);
        };

        $scope.set_propuestaDeSubasta = function () {
            alert('Si sirvio');
            /*fct_MyLearn_API_Client.get({ type: 'Estudiantes', extension1: $routeParams.IdUser }).$promise.then(function (data) {
                $scope.js_datosEstudiante = data;
            });*/
        };

    }]);