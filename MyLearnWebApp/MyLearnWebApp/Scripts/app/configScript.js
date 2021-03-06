﻿angular.module('mod_MyLearn').config(['$routeProvider', function ($routeProvider) {
    $routeProvider

    .when('/MyLearn/CrearCuentaComo', {
        templateUrl: 'Vistas/Login/CrearCuenta_Como.html',
        controller: 'ctrl_crearCuentaComo'
    })
/*-------------------------------------Profesor-------------------------------------------*/
    .when('/MyLearn/Profesor/CrearCuenta', {
        templateUrl: 'Vistas/Profesor/Crear_CuentaProfesor.html',
        controller: 'ctrl_crearCuentaProfesor'
    })
    .when('/MyLearn/Profesor/Perfil/:IdUser', {
        templateUrl: 'Vistas/Profesor/Perfil_Profesor.html',
        controller: 'ctrl_perfilProfesor'
    })

    .when('/MyLearn/Profesor/Perfil/AreaDeTrabajoProfesor', {
        templateUrl: 'Vistas/Profesor/Perfil_Profesor.html',
        controller: 'ctrl_perfilProfesor'
    })

    .when('/MyLearn/Profesor/Perfil/CrearCurso/:IdUser', {
        templateUrl: 'Vistas/Profesor/Crear_Curso.html',
        controller: 'ctrl_crearCurso'
    })

    .when('/MyLearn/Profesor/Perfil/CursoProfesor/:IdUser/:IdCurso', {
        templateUrl: 'Vistas/Profesor/Curso_Profesor.html',
        controller: 'ctrl_cursoProfesor'
    })

    .when('/MyLearn/Estudiante/Perfil/AreaTrabajoProfesor/:IdUser/:IdTrabajo/:IdEst/:IdCurso', {
        templateUrl: 'Vistas/Profesor/AreaTrabajoProf_ProyCurso.html',
        controller: 'ctrl_areaTrabajoProfesor'
    })

    .when('/MyLearn/Estudiante/Perfil/AreaTrabajoProfesorLectura/:IdUser/:IdTrabajo/:IdEst/:IdCurso', {
        templateUrl: 'Vistas/Profesor/AreaTrabajoProf_ProyCursoLectura.html',
        controller: 'ctrl_areaTrabajoProfesor'
    })

/*-------------------------------------Empresa-------------------------------------------*/


    .when('/MyLearn/Empresa/CrearCuenta', {
        templateUrl: 'Vistas/Empresa/Crear_CuentaEmpresa.html',
        controller: 'ctrl_crearCuentaEmpresa'
    })

    .when('/MyLearn/Empresa/Perfil/:IdUser', {
        templateUrl: 'Vistas/Empresa/Perfil_Empresa.html',
        controller: 'ctrl_perfilEmpresa'
    })

    .when('/MyLearn/Empresa/CrearSubasta/:IdUser', {
        templateUrl: 'Vistas/Empresa/CrearSubasta.html',
        controller: 'ctrl_crearSubasta'
    })

    .when('/MyLearn/Empresa/Subasta/:id/:idEmp/:nombre/:presupuesto', {
        templateUrl: 'Vistas/Empresa/Subasta_Empresa.html',
        controller: 'ctrl_subasta'
    })

    .when('/MyLearn/Empresa/Perfil/AreaDeTrabajo/:IdUser/:IdTrabajo/:IdEst', {
        templateUrl: 'Vistas/Empresa/AreaTrabajoEmpresa_ProyEmpresa.html',
        controller: 'ctrl_areaTrabajoEmpresa'
    })
    .when('/MyLearn/Empresa/Perfil/AreaDeTrabajoLectura/:IdUser/:IdTrabajo/:IdEst', {
        templateUrl: 'Vistas/Empresa/AreaTrabajoEmpresa_ProyEmpresaLectura.html',
        controller: 'ctrl_areaTrabajoEmpresa'
    })


/*-------------------------------------Estudiante----------------------------------------*/

    .when('/MyLearn/Estudiante/CrearCuenta', {
        templateUrl: 'Vistas/Estudiante/Crear_CuentaEstudiante.html',
        controller: 'ctrl_crearCuentaEstudiante'
    })
    .when('/MyLearn/Estudiante/Perfil/:IdUser', {
        templateUrl: 'Vistas/Estudiante/Perfil_Estudiante.html',
        controller: 'ctrl_perfilEstudiante'
    })
    .when('/MyLearn/Estudiante/Perfil/:IdUser/CursosDisponibles', {
        templateUrl: 'Vistas/Estudiante/Cursos_Disponibles.html',
        controller: 'ctrl_cursosDisponibles'
    })
    .when('/MyLearn/Estudiante/Perfil/:IdUser/OfertarSubasta/:IdSub', {
        templateUrl: 'Vistas/Estudiante/Ofertar_Subasta.html',
        controller: 'ctrl_ofertarSubasta'
    })
    .when('/MyLearn/Estudiante/Perfil/ProponerProyecto/:IdUser/:IdCurso', {
        templateUrl: 'Vistas/Estudiante/Proponer_Proyecto.html',
        controller: 'ctrl_proponerProyecto'
    })
    .when('/MyLearn/Estudiante/Perfil/:IdUser/SubastaEstudiante', {
        templateUrl: 'Vistas/Estudiante/Subasta_Estudiante.html',
        controller: 'ctrl_subastaEstudiante'
    })
    .when('/MyLearn/Estudiante/Perfil/AreaTrabajo/:IdUser/:IdTrabajo', {
        templateUrl: 'Vistas/Estudiante/AreaTrabajoEst_ProyEmpresa.html',
        controller: 'ctrl_areaTrabajoEstudianteEmpresa'
    })
    .when('/MyLearn/Estudiante/Perfil/AreaTrabajoLectura/:IdUser/:IdTrabajo', {
        templateUrl: 'Vistas/Estudiante/AreaTrabajoEst_ProyEmpresaLectura.html',
        controller: 'ctrl_areaTrabajoEstudianteEmpresa'
    })
    .when('/MyLearn/Estudiante/Perfil/AreaTrabajoEstudianteProfesor/:IdUser/:IdTrabajo', {
        templateUrl: 'Vistas/Estudiante/AreaTrabajoEst_ProyCurso.html',
        controller: 'ctrl_areaTrabajoEstudianteProfesor'
    })
    .when('/MyLearn/Estudiante/Perfil/AreaTrabajoEstudianteProfesorLectura/:IdUser/:IdTrabajo', {
        templateUrl: 'Vistas/Estudiante/AreaTrabajoEst_ProyCursoLectura.html',
        controller: 'ctrl_areaTrabajoEstudianteProfesor'
    })
    .when('/MyLearn/AyudaenLinea', {
        templateUrl: 'Vistas/Login/Ayuda_enLinea.html',
        controller: 'ctrl_ayudaEnLinea'
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