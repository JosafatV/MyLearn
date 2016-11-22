//Var used to save the URL 
var urlGeneric = 'http://192.168.0.108';

//This script is the resource that is used to connect to the web Api od DrPhischel
angular.module('mod_MyLearn').factory('fct_MyLearn_API_Client', function ($resource) {
    return $resource(urlGeneric + ':8099/MyLearnApi/:type/:extension1/:extension2/:extension3/:extension4/:extension5/:extension6', {}, {
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

angular.module('mod_MyLearn').factory('fct_User', function ($resource) {

    var id = '1';
    var contrasena = '';

    this.setId = function (str_newId) {
        id = str_newId;
    };

    this.setContra = function (str_newContra) {
        contrasena = str_newContra;
    };

    this.getContra = function () {
        return str_newContra;
    };

    this.getId = function () {
        return id;
    };

    return this

});

angular.module('mod_MyLearn').factory('fct_Trabajo', function ($resource) {

    var js_trabajo = {};

    this.set_trabajo = function (js_newTrabajo) {
        js_trabajo = js_newTrabajo;
    };


    this.get_trabajo = function () {
        return js_trabajo;
    };


    return this

});

