﻿angular.module('mod_MyLearn').controller('loginController', ['$q','$scope', '$routeParams', '$location', 'ModalService', 'waveWebApiResource', 'twitterService',
    function ($q, $scope, $routeParams, $location, ModalService, waveWebApiResource, twitterService) {

        $scope.goCrearCuenta = function () {
            $location.path("/MyLearn/Estudiante/CrearCuenta");
        };

    }]);
