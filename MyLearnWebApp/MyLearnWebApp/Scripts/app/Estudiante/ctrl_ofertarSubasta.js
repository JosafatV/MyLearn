angular.module('mod_MyLearn').controller('ctrl_ofertarSubasta', ['srcv_cerrarSesion', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (srcv_cerrarSesion,$q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {


        $scope.envioExitoso = false;
        $scope.envioFallido = false;
        $scope.js_datosSubasta = {};
        $scope.js_datosEstudiante = {};
        $scope.ls_otrasSubastas = [];
        $scope.stringTecnologias = "";
        $scope.js_datosOferta = {
            "IdTrabajo": $routeParams.IdSub,
            "IdEstudiante": $routeParams.IdUser,
            "Monto": "",
            "FechaFinalizacion": "",
            "Comentario": "",
        };
        var ls_tecnologias = [];

        /*
        * Service necesario para cerrar sesion
        */
        $scope.cerrarSesionService = srcv_cerrarSesion;

        fct_MyLearn_API_Client.get({ type: 'Estudiantes', extension1: $routeParams.IdUser }).$promise.then(function (data) {
            $scope.js_datosEstudiante = data;
        });

        fct_MyLearn_API_Client.get({ type: 'Subastas', extension1: $routeParams.IdSub }).$promise.then(function (data) {
            $scope.js_datosSubasta = data;
            fct_MyLearn_API_Client.query({
                type: 'Subastas', extension1: 'Ofertas', extension2: data.IdEmpresa.trim()
                            , extension3: $routeParams.IdSub
            }).$promise.then(function (data) {
                $scope.ls_otrasSubastas = data;
            });
        });

        fct_MyLearn_API_Client.query({ type: 'Trabajos',extension1:'Tecnologias' ,extension2: $routeParams.IdSub }).$promise.then(function (data) {
            ls_tecnologias = data;            
            armarString(ls_tecnologias);
        });


        function armarString(lista) {            
            angular.forEach(ls_tecnologias, function (value, key) {               
                $scope.stringTecnologias = $scope.stringTecnologias + ' '+ value.Nombre;
            });
        };



        $scope.set_postSubastas = function () {
            fct_MyLearn_API_Client.save({ type: 'Subastas', extension1: 'Ofertas' }, $scope.js_datosOferta).$promise.then(function (data) {
                $scope.envioExitoso = true;
                $scope.envioFallido = false;
            }, function (error) {
                $scope.envioFallido = true;
            });
        };

        $scope.do_goPerfilEstudiante = function () {
            $location.path('/MyLearn/Estudiante/Perfil/' + $routeParams.IdUser);
        };
        $scope.goCursosDisponibles = function () {
            $location.path('/MyLearn/Estudiante/Perfil/' + $routeParams.IdUser + '/CursosDisponibles');
        };

        $scope.set_propuestaDeSubasta = function () {
            alert('Si sirvio');
            /*fct_MyLearn_API_Client.get({ type: 'Estudiantes', extension1: $routeParams.IdUser }).$promise.then(function (data) {
                $scope.js_datosEstudiante = data;
            });*/
        };

    }]);