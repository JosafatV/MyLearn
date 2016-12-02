angular.module('mod_MyLearn').service('cerrarSesion', ['$location','$http', '$q', function ($location,$http, $q) {
    this.cerrarEstaSesion = function () {
        $location.path('/MyLearn/CerrarSesion');
    }
}]);
