angular.module('mod_MyLearn').controller('ctrl_ofertarSubasta', ['$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function ($q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.goPerfil = function () {
            $location.path('/MyLearn/Estudiante/Perfil');
        };

    }]);
