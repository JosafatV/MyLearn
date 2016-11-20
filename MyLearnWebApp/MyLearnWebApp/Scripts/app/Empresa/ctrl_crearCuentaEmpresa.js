angular.module('mod_MyLearn').controller('ctrl_crearCuentaEmpresa', ['$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService',
    function ($q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService) {

        $scope.goCrearCuenta = function () {
            $location.path("/MyLearn/Estudiante/CrearCuenta");
        };

        $scope.usuario = "";
        $scope.contrasenia = "";

        $scope.crearCuentaJson = {
            Id: "sample string 1jhgf",
            NombreContacto: "sample string 2",
            ApellidoContacto: "sample string 3",
            NombreEmpresarial: "sample string 4",
            Email: "sample string 5",
            Telefono: "sample string 6",
            Foto: "sample string 7",
            FechaInscripcion: "2016-11-19T21:07:30.9809778-06:00",
            PaginaWebEmpresa: "sample string 9",
            Pais: "sample string 10",
            Region: "sample string 11",
            Contrasena: "sample string 12",
            RepositorioArchivos: "sample string 14",
            CredencialDrive: "sample string 15"
        }

        $scope.sendCuenta = function () {

            fct_MyLearn_API_Client.save({ type: 'Empresas' }, Json);

        }

    }]);