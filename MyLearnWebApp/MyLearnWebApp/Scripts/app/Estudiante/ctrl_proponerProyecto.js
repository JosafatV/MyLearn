angular.module('mod_MyLearn').controller('ctrl_proponerProyecto', ['$q', '$scope', '$routeParams', '$location', 'ModalService', 'fct_MyLearn_API_Client', 'twitterService', '$uibModal',
    function ($q, $scope, $routeParams, $location, ModalService, fct_MyLearn_API_Client, twitterService, uibModal) {

        $scope.js_datosEstudiante = {};
        $scope.js_datosCurso = {};
        $scope.publicadoExitosamente = false;
        $scope.publicadoErroneamente = false;

        $scope.js_proponerProyecto = {
            "IdEstudiante": $routeParams.IdUser,
            "IdProfesor": "",
            "NombreProyecto": "",
            "Problematica": "",
            "Descripcion": "",
            "IdCurso": $routeParams.IdCurso,
            "FechaFinal": "",
            "DocumentoAdicional": "",
        }

        fct_MyLearn_API_Client.get({ type: 'Cursos', extension1: $routeParams.IdCurso }).$promise.then(function (data) {
            $scope.js_datosCurso = data;
        });

        fct_MyLearn_API_Client.get({ type: 'Estudiantes', extension1: $routeParams.IdUser }).$promise.then(function (data) {
            $scope.js_datosEstudiante = data;
        });

        $scope.set_savePropuesta = function () {
            $scope.js_proponerProyecto.IdProfesor = $scope.js_datosCurso.IdProfesor;
            fct_MyLearn_API_Client.save({ type: 'Proyectos' }, $scope.js_proponerProyecto).$promise.then(function (data) {
                $scope.publicadoExitosamente = true;
                $scope.publicadoErroneamente = false;
                $scope.js_proponerProyecto = {};
         }, function (error) {
             $scope.publicadoExitosamente = false;
             $scope.publicadoErroneamente = true;
         });
            
        };

        $scope.do_goPerfil = function () {
            $location.path('/MyLearn/Estudiante/Perfil/' + $routeParams.IdUser);
        };
    }]);
