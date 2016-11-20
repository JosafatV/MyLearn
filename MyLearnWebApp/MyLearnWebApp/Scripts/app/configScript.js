﻿angular.module('mod_MyLearn').config(['$routeProvider', function ($routeProvider) {
    $routeProvider
/*-------------------------------------Profesor-------------------------------------------*/
    .when('/MyLearn/Profesor/CrearCuenta', {
        templateUrl: 'Vistas/Profesor/Crear_CuentaProfesor.html',
        controller: 'ctrl_crearCuentaProfesor'
    })

/*-------------------------------------Empresa-------------------------------------------*/
/*-------------------------------------Estudiante----------------------------------------*/

    .when('/MyLearn/Estudiante/CrearCuenta', {
        templateUrl: 'Vistas/Estudiante/Crear_CuentaEstudiante.html',
        controller: 'ctrl_crearCuentaEstudiante'
    })
    .when('/MyLearn/Estudiante/Perfil', {
        templateUrl: 'Vistas/Estudiante/Perfil_Estudiante.html',
        controller: 'ctrl_perfilEstudiante'
    })
    .when('/MyLearn/Estudiante/Perfil/CursosDisponibles', {
        templateUrl: 'Vistas/Estudiante/Cursos_Disponibles.html',
        controller: 'ctrl_cursosDisponibles'
    })
    .when('/MyLearn/Estudiante/Perfil/OfertarSubasta', {
        templateUrl: 'Vistas/Estudiante/Ofertar_Subasta.html',
        controller: 'ctrl_ofertarSubasta'
    })
    .when('/MyLearn/Estudiante/Perfil/ProponerProyecto', {
        templateUrl: 'Vistas/Estudiante/Proponer_Proyecto.html',
        controller: 'ctrl_proponerProyecto'
    })
    .when('/MyLearn/Estudiante/Perfil/SubastaEstudiante', {
        templateUrl: 'Vistas/Estudiante/Subasta_Estudiante.html',
        controller: 'ctrl_subastaEstudiante'
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