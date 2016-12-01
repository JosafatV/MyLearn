angular.module('mod_MyLearn').controller('ctrl_crearCuentaEmpresa', ['$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService',
    function ($q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService) {

        $scope.publicadoExitosamente = false;
        $scope.publicadoErroneamente = false;

        var access_token = "";
        var refresh_token = "";
        var client_id = "";

        OAuth.initialize('CgKcLvAzYP_vq69R1HNBPtTne_g');
        OAuth.create('google_drive');

        $scope.usuario = "";
        $scope.contrasenia = "";

        $scope.js_crearCuenta = {
            NombreDeUsuario: "",
            NombreContacto: "",
            ApellidoContacto: "",
            NombreEmpresarial: "",
            Email: "",
            Telefono: "",
            Foto: "",
            PaginaWebEmpresa: "",
            Pais: "",
            Region: "",
            Contrasena: "",
            RepositorioArchivos: "",
            CredencialDrive: ""
        }


        fct_MyLearn_API_Client.query({ type: 'Paises' }).$promise.then(function (data) {
            $scope.ls_listaPaises = data;
        });

        $scope.changePais = function () {
            $scope.js_crearCuenta.Pais = $scope.paisSelected.Pais1;
        };

        $scope.set_sendCuenta = function () {            
            fct_MyLearn_API_Client.save({ type: 'Empresas' }, $scope.js_crearCuenta).$promise.then(function (data) {
                set_sendCredentials(data.Id);
                $scope.publicadoExitosamente = true;
                $scope.publicadoErroneamente = false;
            }, function (error) {
                $scope.publicadoExitosamente = false;
                $scope.publicadoErroneamente = true;
            });
        }

        /*
        * Esta es la funcion encargada de conectar con Drive
        */

        $scope.testDrive = function () {            
            OAuth.clearCache();
            OAuth.popup('google_drive', { cache: false }).done(function (result) {
                console.log(result);
                access_token = result.access_token;
                refresh_token = result.refresh_token;
            })
        };


        /*
        * Función encargada de enviar las credential 
        */

        function set_sendCredentials(id) {
            fct_MyLearn_API_Client.save({ type: 'DriveCredentials' }, {
                "UserId": id,
                "AccessToken": access_token,
                "RefreshToken": refresh_token
            }).$promise.then(function (data) {
                $location.path('/MyLearn/Empresa/Perfil/' + id);
            });
        };

        $scope.goCrearCuenta = function () {
            $location.path("/MyLearn/CrearCuentaComo");
        };

    }]);