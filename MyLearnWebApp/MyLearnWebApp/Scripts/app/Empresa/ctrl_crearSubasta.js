angular.module('mod_MyLearn').controller('ctrl_crearSubasta', ['fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.do_goPerfil = function () {
            $location.path('/MyLearn/Empresa/Perfil/' + $routeParams.IdUser);
        };

        $scope.js_crearSubasta = {
            "Nombre": "",
            "Descripcion": "",
            "IdEmpresa": $routeParams.IdUser,
            "FechaCierre": "",
            "PresupuestoBase": ""
        }

        $scope.set_newSubasta = function () {

            fct_MyLearn_API_Client.save({ type: 'Subastas' }, $scope.js_crearSubasta).$promise.then(function (data) {
                $scope.js_crearSubasta = {
                    "Nombre": "",
                    "Descripcion": "",
                    "IdEmpresa": $routeParams.IdUser,
                    "FechaCierre": "",
                    "PresupuestoBase": ""
                }
            });

        };



    }]);
