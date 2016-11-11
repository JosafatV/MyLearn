

angular.module('mod_MyLearn').controller('loginController', ['$q','$scope', '$routeParams', '$location', 'ModalService', 'waveWebApiResource', 'twitterService',
    function ($q,$scope, $routeParams, $location, ModalService, waveWebApiResource, twitterService) {   
        $scope.connectedTwitter = false;
        //Cambio del Login  
        $scope.tweets = [];
        $scope.test = 'Test1';
        //twitterService.initialize();
        OAuth.initialize('CgKcLvAzYP_vq69R1HNBPtTne_g');
        var drive = false; 


        $scope.testTwitter1 = function () {
            twitterService.connectTwitter().then(function () {
                if (twitterService.isReady()) {
                    $scope.connectedTwitter = true;
                }
            });
        };

        $scope.testTwitter2 = function (maxId) {          
            $scope.token = twitterService.setTokenPublic();
            $scope.tokenSecret = twitterService.setTokenSecret();
        };

        $scope.postTwitter = function (maxId) {
            twitterService.postTweet();
        };

        $scope.alerte = function () {
            twitterService.clearCache();
        };

        $scope.testDrive = function () {
            
            OAuth.popup('google_drive').done(function (result) {
                console.log(result);
                drive = result;
                // do some stuff with result
            })
        };

        $scope.getDriveFiles = function () {
            var deferred = $q.defer();
            $scope.dataDrive = "pn";
            drive.get("/drive/v2/files").done(function (data) {
                deferred.resolve(data);
                $scope.dataDrive = data; 
                alert(angular.toJson(data));
            });
        };

        $scope.getOneFile = function () {   
            var deferred = $q.defer();
            drive.get("/drive/v2/files/0B3J4vu79le9rcEQ3OVoyek1OcjQ").done(function (data) {
                deferred.resolve(data);
                $scope.dataDrive = data; 
                alert(angular.toJson(data));
            });
        };
    }]);
