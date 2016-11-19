//Var used to save the URL 
var urlGeneric = 'http://192.168.2.13';

//This script is the resource that is used to connect to the web Api od DrPhischel
angular.module('mod_MyLearn').factory('waveWebApiResource', function ($resource) {
    return $resource(urlGeneric + ':8093/api/:type/:extension1/:extension2/:extension3/:extension4/:extension5/:extension6', {}, {
        query: {
            method: 'GET',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' },
            transformResponse: function (data) {
                return angular.fromJson(data);
            },
            isArray: true
        },
        get: {
            method: 'GET',
            transformResponse: function (data) {
                return angular.fromJson(data);
            },
            isArray: false
        },
        save: {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }            
        },
        saveList: {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            },
            isArray: true
        },
        update: {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }
        },
        delete: { method: 'DELETE' }
    });
});
