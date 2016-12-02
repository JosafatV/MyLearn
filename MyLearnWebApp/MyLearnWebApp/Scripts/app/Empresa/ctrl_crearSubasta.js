angular.module('mod_MyLearn').controller('ctrl_crearSubasta', ['srcv_cerrarSesion', 'fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (srcv_cerrarSesion,fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.ls_tecnologias = [];
        $scope.ls_tecnologiasSelect = [];

        $scope.js_crearSubasta = {
            "Nombre": "",
            "Descripcion": "",
            "IdEmpresa": $routeParams.IdUser,
            "FechaCierre": "",
            "PresupuestoBase": ""
        }

        /*
        * Service necesario para cerrar sesion
        */
        $scope.cerrarSesionService = srcv_cerrarSesion;

        fct_MyLearn_API_Client.query({ type: 'Tecnologias' }).$promise.then(function (data) {
            $scope.ls_tecnologias = data;
        });

        $scope.do_goPerfil = function () {
            $location.path('/MyLearn/Empresa/Perfil/' + $routeParams.IdUser);
        };

        $scope.set_crearSubasta = function () {
            fct_MyLearn_API_Client.save({ type: 'Subastas' }, $scope.js_crearSubasta).$promise.then(function (data) {
                $scope.js_crearSubasta = {};
                angular.forEach($scope.ls_tecnologiasSelect, function (value, key) {
                    fct_MyLearn_API_Client.save({ type: 'Subastas', extension1: 'Tecnologia' }, { IdTecnologia: value.Id, IdTrabajo: data.Id}).$promise.then(function (data) {
                    }, function (error) {
                        alert('Error al publicar las tecnologias')
                    });
                });
            }, function (error) {
                alert("Error al publicar la subasta");
            });
        };

        $scope.do_doleteSelected = function (tec) {
            $scope.ls_tecnologias.push(tec);
            $scope.ls_tecnologiasSelect.splice($scope.ls_tecnologiasSelect.indexOf(tec), 1);
        };

        $scope.do_agregueTec = function (tec) {
            $scope.ls_tecnologiasSelect.push(tec);
            $scope.ls_tecnologias.splice($scope.ls_tecnologias.indexOf(tec), 1);
        };

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
