angular.module('mod_MyLearn').controller('ctrl_crearSubasta', ['fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.do_goPerfil = function () {
            $location.path('/MyLearn/Empresa/Perfil');
        };

    }]);
