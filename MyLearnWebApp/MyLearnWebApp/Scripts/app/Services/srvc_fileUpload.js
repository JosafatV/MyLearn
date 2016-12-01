angular.module('mod_MyLearn').service('fileUpload', ['$http', function ($http) {
    this.uploadFileToUrl = function (file,id) {
        var fd = new FormData();
        fd.append('file', file);

        $http.post(urlGeneric + ':8099/MyLearnApi/File/'+ id, fd, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })

    }
}]);
