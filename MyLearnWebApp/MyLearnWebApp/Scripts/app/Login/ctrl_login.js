angular.module('mod_MyLearn').controller('ctrl_login', ['fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {
        

        var str_id = "20";
        var contrasena = "Contraseña"

        fct_User.setId("20");
        fct_User.setContra("this");

        $scope.goCrearCuentaEstudiante = function () {
            $location.path("/MyLearn/Estudiante/CrearCuenta");
        };

        $scope.goCrearProfesor = function () {
            $location.path("/MyLearn/Profesor/CrearCuenta");
        };

        $scope.goCrearCuentaEmpresa = function () {
            $location.path("/MyLearn/Empresa/CrearCuenta");
        };

        $scope.goPerfil = function () {
            alert($scope.usuario);
            $location.path('/MyLearn/Estudiante/Perfil');
        };

        $scope.do_goPerfilEmpresa = function () {
            $location.path('/MyLearn/Empresa/Perfil');
        };

        $scope.testModal = function () {
            uibModal.open({
                animation: true,
                templateUrl: 'Vistas/Estudiante/Perfil_Estudiante.html',
                controller: 'ctrl_login',
                size: 'lg'
            })
        };

    }]);
