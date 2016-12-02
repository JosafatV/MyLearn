angular.module('mod_MyLearn').service('srcv_cerrarSesion', ['$location','$http', '$q', function ($location,$http, $q) {
    this.cerrarEstaSesion = function () {
        $location.path('/MyLearn/CerrarSesion');
    }
}]);
