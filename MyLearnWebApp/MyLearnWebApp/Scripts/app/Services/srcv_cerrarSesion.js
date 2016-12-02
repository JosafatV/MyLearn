angular.module('mod_MyLearn').service('cerrarSesion', ['$http', '$q', function ($http, $q) {
    this.cerrarSesion = function () {
        $location.path('/MyLearn/Empresa/CerrarSesion');
    }
}]);
