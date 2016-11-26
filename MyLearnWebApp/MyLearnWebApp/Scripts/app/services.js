angular.module('mod_MyLearn').service('fileUpload', ['fct_MyLearn_API_Client', function ($http) {
    this.uploadFileToUrl = function (file, uploadUrl) {
        var fd = new FormData();
        fd.append('file', file);

    }
}]);