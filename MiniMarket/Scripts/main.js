var proveedores = angular.module('proveedores', ["ngSanitize"]);

proveedores.factory("listaproveedores", function ($http) {
    var factoria = {};
    factoria.listaproveedores = function () {
        return $http.get("http://localhost:61093/proveedors/listaproveedores");
    }
    return factoria; listaproveedores
});

proveedores.controller("proveedorescontroller", function ($scope, listaproveedores) {
    listaproveedores.listaproveedores().success(function (datos) {
        $scope.listaproveedores = datos

    }); 
});