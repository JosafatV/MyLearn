angular.module('mod_MyLearn').controller('ctrl_subastaEstudiante', ['$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function ($q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.str_tecnologia = '~';
        $scope.str_nombre = '~';
        $scope.ls_tecnologias = '';
        $scope.ls_resultadoBusqueda = '';

        fct_MyLearn_API_Client.get({ type: 'Estudiantes', extension1: $routeParams.IdUser }).$promise.then(function (data) {
            $scope.js_datosEstudiante = data;
        });

        fct_MyLearn_API_Client.query({ type: 'Tecnologias' }).$promise.then(function (data) {
            $scope.ls_tecnologias = data;
        });

        $scope.get_subastas = function () {
            alert($scope.str_tecnologia);
            fct_MyLearn_API_Client.query({ type: 'Subastas', extension1: $scope.str_tecnologia.Id, extension2: $scope.str_nombre, extension3: $routeParams.IdUser }).$promise.then(function (data) {
                $scope.ls_resultadoBusqueda = data;
            });            
        };

        $scope.go_ofertarSubasta = function (subasta) {
            $location.path('/MyLearn/Estudiante/Perfil/' + $routeParams.IdUser + '/OfertarSubasta/' + subasta.Id);
        };

        $scope.goPerfil = function () {
            $location.path('/MyLearn/Estudiante/Perfil');
        };

    }]);
