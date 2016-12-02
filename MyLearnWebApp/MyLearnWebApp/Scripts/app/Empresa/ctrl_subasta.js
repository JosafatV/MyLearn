angular.module('mod_MyLearn').controller('ctrl_subasta', ['srcv_cerrarSesion', 'fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (srcv_cerrarSesion,fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.nombreProyecto = $routeParams.nombre;
        $scope.presupuestoBasex = $routeParams.presupuesto;
        get_listaSubastas();

        /*
        * Service necesario para cerrar sesion
        */
        $scope.cerrarSesionService = srcv_cerrarSesion;

        $scope.do_goPerfil = function () {
            $location.path('/MyLearn/Empresa/Perfil/' + $routeParams.idEmp.trim());
        };

        $scope.do_goCrearSubasta = function () {
            $location.path('/MyLearn/Empresa/CrearSubasta/' + $routeParams.idEmp);

        };

        $scope.do_aceptarPropuesta = function (propuesta) {
            fct_MyLearn_API_Client.save({
                type: 'Trabajos', extension2: parseInt($routeParams.id), extension3:parseInt(propuesta.IdEstudiante)
            }, {}).$promise.then(function (data) {
                get_listaSubastas()
            });
           
        };

        function get_listaSubastas() {
            fct_MyLearn_API_Client.query({
                type: 'Subastas', extension1: "Ofertas", extension2: parseInt($routeParams.idEmp),
                extension3: parseInt($routeParams.id)
            }).$promise.then(function (data) {
                $scope.ls_propuestas = data;
            });

        };
      




    }]);
