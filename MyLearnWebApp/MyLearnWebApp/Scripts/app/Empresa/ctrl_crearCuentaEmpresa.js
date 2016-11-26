angular.module('mod_MyLearn').controller('ctrl_crearCuentaEmpresa', ['$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService',
    function ($q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService) {

        $scope.publicadoExitosamente = false;
        $scope.publicadoErroneamente = false;

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
                $scope.publicadoExitosamente = true;
                $scope.publicadoErroneamente = false;
            }, function (error) {
                $scope.publicadoExitosamente = false;
                $scope.publicadoErroneamente = true;
            });
        }

        $scope.goCrearCuenta = function () {
            $location.path("/MyLearn/CrearCuentaComo");
        };

    }]);