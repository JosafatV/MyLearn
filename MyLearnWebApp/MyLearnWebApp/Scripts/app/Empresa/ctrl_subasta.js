angular.module('mod_MyLearn').controller('ctrl_subasta', ['fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.nombreProyecto = $routeParams.nombre;
        $scope.presupuestoBasex = $routeParams.presupuesto;

        $scope.do_goPerfil = function () {
            $location.path('/MyLearn/Empresa/Perfil');
        };

        $scope.do_goCrearSubasta = function () {
            $location.path('/MyLearn/Empresa/CrearSubasta');

        };

        $scope.do_aceptarPropuesta = function (propuesta) {
            alert(parseInt($routeParams.id));
            alert(propuesta.IdEstudiante);
            fct_MyLearn_API_Client.save({
                type: 'Trabajos', extension2: parseInt($routeParams.id), extension3:parseInt(propuesta.IdEstudiante)
            }, {}).$promise.then(function (data) {                
            });
           
        };

            fct_MyLearn_API_Client.query({ type: 'Subastas',extension1: "Ofertas",extension2: parseInt($routeParams.idEmp),
                extension3: parseInt($routeParams.id) }).$promise.then(function (data) {
                    $scope.ls_propuestas = data;
            });




    }]);
