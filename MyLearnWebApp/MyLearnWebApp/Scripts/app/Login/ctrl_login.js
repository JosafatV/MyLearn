var str_id = 13;
angular.module('mod_MyLearn').controller('ctrl_login', ['fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {
        
        var contrasena = "Contraseña"
        $scope.usuario = "";
        $scope.contrasena = "";
        $scope.bool_errorLogin = false;

        fct_User.setId(str_id);
        fct_User.setContra("this");

        /*----------Estudiante:
        Usuario: a
        Contraseña: 1234       
        -----------*/
        /*----------Empresa:
        Usuario: m
        Contraseña: 1234       S
        -----------*/
        /*----------Profesor:
        Usuario: e
        Contraseña: 1234       
        -----------*/

        $scope.login = function () {
            fct_MyLearn_API_Client.query({  type: 'Usuario', extension1: $scope.usuario, extension2: 'Password', extension3: $scope.contrasena }).$promise.then(function (data) {
                go_perfilUsuario(data[0].Links[0].href,data[0].Id.trim());
            }, function(error) {
                console.log(error);
                $scope.bool_errorLogin = true;
            });
        };

        function go_perfilUsuario(url, id) {
            $location.path(url + id);
        };

        $scope.goCrearCuentaEstudiante = function () {
            $location.path("/MyLearn/Estudiante/CrearCuenta");
        };

        $scope.goCrearCuentaProfesor = function () {
            $location.path("/MyLearn/Profesor/CrearCuenta");
        };

        $scope.goCrearCuentaEmpresa = function () {
            $location.path("/MyLearn/Empresa/CrearCuenta");
        };

        $scope.do_goPerfilEstudiante = function () {
            $location.path('/MyLearn/Estudiante/Perfil/' + str_id);
        };

        $scope.do_goPerfilProfesor = function () {
            $location.path('/MyLearn/Profesor/Perfil/' + str_id);
        };

        $scope.do_goPerfilEmpresa = function () {
            $location.path('/MyLearn/Empresa/Perfil/' + str_id);
        };

        $scope.goAreaTrabajoEstudianteProfesor = function () {
            $location.path('/MyLearn/Estudiante/Perfil/AreaTrabajoEstudianteProfesor/'+2+'/'+1);
        };

        $scope.goAreaTrabajoProfesor = function () {
            $location.path('/MyLearn/Estudiante/Perfil/AreaTrabajoProfesor/' + 13 + '/' + 2 +'/'+ 1);
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
