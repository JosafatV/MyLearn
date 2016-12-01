angular.module('mod_MyLearn').controller('ctrl_crearCuentaProfesor', ['$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService',
    function ($q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService) {
        $scope.universidadSelected = "";
        $scope.ls_listaUniversidades = [];

        /*
        *  Estructura del json necesario para poder crear la cuenta
        *
        */

        $scope.crearCuentaJson =
           {
               "NombreDeUsuario": "",
               "Contrasena": "",
               "Sal": "",
               "RepositorioArchivos": "",
               "CredencialDrive": "",
               "Estado": "",
               "NombreContacto": "",
               "ApellidoContacto": "",
               "Email": "",
               "Telefono": "",
               "Foto": null,
               "Pais": "",
               "HorarioAtencion": "",
               "Region": "",
               "IdUniversidad": 2,
               "Universidad": ""
           }

        $scope.paisSelected = "";
        $scope.usuario = "";
        $scope.contrasenia = "";

        /*
        *  Con esta llamada a la factory se piden las universidades que puede seleccionar el profesor al incluirse
        *
        */

        fct_MyLearn_API_Client.query({ type: 'Universidades' }).$promise.then(function (data) {
            $scope.ls_listaUniversidades = data;
        });

        /*
        *  Con esta llamada a la factory se piden los Paises que puede seleccionar el profesor al incluirse
        *
        */


        fct_MyLearn_API_Client.query({ type: 'Paises' }).$promise.then(function (data) {
            $scope.listaPaises = data;
        });

        /*
        *  Esta es la funcion encargada de cambiar la universidad cuando el usuario cambie su seleccion
        *
        */

        $scope.changeUniversidad = function () {
            $scope.crearCuentaJson.IdUniversidad = $scope.universidadSelected.Id;
        };

        /*
        *  Con esta función se cambia el pais una vez que el usuario haya seleccionado un pais
        *  o cambiado su seleccion por otra.
        *
        */


        $scope.changePais = function () {
            $scope.crearCuentaJson.Pais = $scope.paisSelected.Pais1;
        };

        /*
        *  Funcion encargada de movilizarse al crer cuaenta del estudiante
        *
        */

        $scope.goCrearCuenta = function () {
            $location.path("/MyLearn/Estudiante/CrearCuenta");
        };

        /*
        *  Funcion encardada de enviar la solicitud de crear cuenta una vez que el usuario decida hacerlo
        *
        */

        $scope.sendCuenta = function () {
            fct_MyLearn_API_Client.save({ type: 'Profesores' }, $scope.crearCuentaJson);

        }

    }]);