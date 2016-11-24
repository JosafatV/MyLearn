var str_id = 13;
angular.module('mod_MyLearn').controller('ctrl_login', ['fct_User', '$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function (fct_User, $q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {
        
        var contrasena = "Contraseña"

        fct_User.setId(str_id);
        fct_User.setContra("this");
       /* fct_UserJson.set_user({
            "NombreContacto": "sample string 1",
            "ApellidoContacto": "sample string 2",
            "Carne": "sample string 3",
            "Email": "sample string 4",
            "Telefono": "sample string 5",
            "Pais": "sample string 6",
            "Region": "sample string 7",
            "FechaInscripcion": "2016-11-21T22:17:21.6527491-06:00",
            "RepositorioCodigo": "sample string 9",
            "LinkHojaDeVida": "sample string 10",
            "Id": str_id,
            "Contrasena": "sample string 12",
            "Sal": "sample string 13",
            "RepositorioArchivos": "sample string 14",
            "CredencialDrive": "sample string 15",
            "Estado": "sample string 16",
            "IdUniversidad": 1
        });*/

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
