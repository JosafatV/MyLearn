angular.module('mod_MyLearn').config(['$routeProvider', function ($routeProvider) {
    $routeProvider
/*-------------------------------------Estudiante-------------------------------------------*/

    .when('/MyLearn/Estudiante/CrearCuenta', {
        templateUrl: 'Vistas/Estudiante/Crear_CuentaEstudiante.html',
        controller: 'ctrl_crearCuentaEstudiantes'
    })  
/*-------------------------------------Default--------------------------------------------*/
    .otherwise({
        templateUrl: 'Vistas/Login/Login.html',
        controller: 'ctrl_login'
    })
}]);

angular.module('mod_MyLearn').config(function ($httpProvider) {
    //$httpProvider.defaults.headers.common = {};
    $httpProvider.defaults.useXDomain = true;
    $httpProvider.defaults.headers.post['Content-Type'] = 'application/json;charset=utf-8';
    //$httpProvider.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
    //$httpProvider.defaults.withCredentials = true;
    //delete $httpProvider.defaults.headers.common["X-Requested-With"];
    //$httpProvider.defaults.headers.common = {};
    //$httpProvider.defaults.headers.post = {};
    //$httpProvider.defaults.headers.put = {};
    //$httpProvider.defaults.headers.patch = {};
});