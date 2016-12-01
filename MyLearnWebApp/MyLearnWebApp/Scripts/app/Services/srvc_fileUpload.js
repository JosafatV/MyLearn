angular.module('mod_MyLearn').service('fileUpload', ['$http', '$q', function ($http, $q) {
    this.uploadFileToUrl = function (file, id) {
        var fd = new FormData();
        fd.append('file', file);
        var deferred = $q.defer();
        $http.post(urlGeneric + ':8099/MyLearnApi/File/' + id, fd, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        }).then(function (data) {
            deferred.resolve('aa');
        });
     return deferred.promise;
    }
}]);
