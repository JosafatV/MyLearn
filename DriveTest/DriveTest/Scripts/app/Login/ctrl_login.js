

angular.module('mod_MyLearn').controller('loginController', ['$window','$q', '$scope', '$routeParams', '$location', 'ModalService', 'waveWebApiResource', 'twitterService', 'gapiService',
    function ($window,$q, $scope, $routeParams, $location, ModalService, waveWebApiResource, twitterService, gapiService) {
        $scope.connectedTwitter = false;
        //Cambio del Login  
        $scope.tweets = [];
        $scope.test = 'Test1';
        //twitterService.initialize();
        OAuth.clearCache('google_drive');
        OAuth.initialize('CgKcLvAzYP_vq69R1HNBPtTne_g');
        $scope.drive = "asdasd";
        var google = true;
        

        $window.initGapi = function() {
            gapiService.initGapi();}

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


        $scope.getDriveCode = function () {           
            OAuth.popup("google_drive", {
                
            }).done(function (result) {
                alert(angular.toJson(result));
                
                //$.post('/auth', { code: result.code })
            })
            
        };

        $scope.test2 = function () {
            alert('aqui0');
            gapiService.loadgapi();

        };

        $scope.getAuthInstance = function () {
            google = gapi.auth2.getAuthInstance()
        };

        $scope.solicitateCode = function () {
            alert('aqui1');

            //google.signIn();
            google.grantOfflineAccess({ 'redirect_uri': 'postmessage' }).then(function (resp) {
                var auth_code = resp.code;
                alert(angular.toJson(auth_code));
            });

        }

        $scope.alerte = function () {
            twitterService.clearCache();
        };

        $scope.testDrive = function () {            
            OAuth.popup('google_drive').done(function (result) {
                console.log(result);
                alert(angular.toJson(result));
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


        var init = function() {
            window.initGapi();
        };





        //Con gapi.-----------------------
        /*

        function start() {
            // 2. Initialize the JavaScript client library.
            gapi.client.init({
                // clientId and scope are optional if auth is not required.
                'clientId': '585034979069-c25comfmduvtpg25vj3nbnofr6h9i8rv.apps.googleusercontent.com',
                'scope': 'https://www.googleapis.com/auth/drive.file',
            }).then(function () {
                // 3. Initialize and make the API request.
                return gapi.client.people.people.get({
                    resourceName: 'people/me'
                });
            }).then(function (resp) {
                console.log(resp.result);
            }, function (reason) {
                console.log('Error: ' + reason.result.error.message);
            });
        };
        // 1. Load the JavaScript client library.
        gapi.load('client', start);

        function handleClientLoad() {
            checkAuth();
        };

      /**
       * Check if the current user has authorized the application.
       */
       /* function checkAuth() {
            gapi.auth.authorize(
                { 'client_id': CLIENT_ID, 'scope': SCOPES, 'immediate': true },
                handleAuthResult);
        };

      /**
       * Called when authorization server replies.
       *
       * @param {Object} authResult Authorization result.
       */
        /*function handleAuthResult(authResult) {
            if (authResult) {
                // Access token has been successfully retrieved, requests can be sent to the API
            } else {
                // No access token could be retrieved, force the authorization flow.
                gapi.auth.authorize(
                    { 'client_id': CLIENT_ID, 'scope': SCOPES, 'immediate': false },
                    handleAuthResult);
            }
        }; */

    }]);


angular.module('mod_MyLearn').service('gapiService', function () {
    this.loadgapi = function () {
        gapi.client.init({
            'clientId':"585034979069-c25comfmduvtpg25vj3nbnofr6h9i8rv.apps.googleusercontent.com",
            'scope': 'https://www.googleapis.com/auth/drive.file',
        });
        
    }

    this.initGapi = function () {
        gapi.load('client:auth2', initClient);
    }

});