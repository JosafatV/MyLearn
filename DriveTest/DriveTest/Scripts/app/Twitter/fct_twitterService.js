
angular.module('mod_MyLearn').factory('twitterService', function ($q) {

    var authorizationResult = false;
    var tokenPublico = '1327984718-8Ao2XiMSrWzSW1HTshvw1NB2ObM4UGjwrzDFcrC';
    var tokenSecreto = 'DHZ03LHYraFGeIfn4c0KFsE2Q8ksbS3EtrR6nOAJLSDVM';
    var listaTokens = { "oauth_token": tokenPublico, "oauth_token_secret": tokenSecreto, provider:"twitter" };
    return {
        initialize: function () {
            //initialize OAuth.io with public key of the application
            OAuth.initialize('CgKcLvAzYP_vq69R1HNBPtTne_g', {
                cache: true
            });
            //try to create an authorization result when the page loads,
            // this means a returning user won't have to click the twitter button again
            authorizationResult = OAuth.create("twitter");
            alert(angular.toJson(authorizationResult));
        },
        isReady: function () {
            return (authorizationResult);
        },
        connectTwitter: function () {
            var deferred = $q.defer();
            OAuth.popup("twitter", {
                cache: true
            }, function (error, result) {
                // cache means to execute the callback if the tokens are already present
                if (!error) {
                    authorizationResult = result;
                    tokenPublico = result.oauth_token;
                    tokenSecreto = result.oauth_token_secret;
                    //alert(angular.toJson(result));
                    deferred.resolve();
                } else {
                    //do something if there's an error

                }
            });
            return deferred.promise;
        },
        clearCache: function () {
            OAuth.clearCache('twitter');
            authorizationResult = false;
        },
        postTweet: function () {
            var urlPost = "/1.1/statuses/update.json?status=test2";
            authorizationResult.post(urlPost);
        },
        getTokenPublic: function () {
            return tokenPublico;
        },
        getTokenSecret: function () {
            return tokenSecreto;
        },
        setTokenPublic: function () {
            authorizationResult.oauth_token = tokenPublico;
        },
        setTokenSecret: function () {
            authorizationResult.oauth_token_secret = tokenSecreto;
        }
    }
});
