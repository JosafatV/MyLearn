angular.module('mod_MyLearn').controller('ctrl_crearSubasta', ['fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.do_goPerfil = function () {
            $location.path('/MyLearn/Empresa/Perfil');
        };

        $scope.js_crearSubasta = {
            "Nombre": "",
            "Descripcion": "",
            "IdEmpresa": fct_User.getId(),
            "FechaCierre": "",
            "PresupuestoBase": ""
        }

        $scope.set_newSubasta = function () {

            fct_MyLearn_API_Client.save({ type: 'Subastas' }, $scope.js_crearSubasta).$promise.then(function (data) {
                alert(angular.toJson(data));
            });

        };



    }]);
