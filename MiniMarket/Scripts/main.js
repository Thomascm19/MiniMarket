/* Datos Proveedores   */
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
/* Datos Clientes   */
var clientes = angular.module('clientes', ["ngSanitize"]);

clientes.factory("listaclientes", function ($http) {
    var factoria = {};
    factoria.listaclientes = function () {
        return $http.get("http://localhost:61093/clientes/listaclientes");
    }
    return factoria; listaclientes
});

clientes.controller("clientescontroller", function ($scope, listaclientes) {
    listaclientes.listaclientes().success(function (datos) {
        $scope.listaclientes = datos

    });
});

/*=============================================
OBJETO CON LAS PROPIEDADES DEL SLIDE
=============================================*/

var p = {

    paginacion: document.querySelectorAll("#paginacion li"),
    item: 0,
    cajaSlide: document.querySelector("#slide ul"),
    animacionSlide: "slide",
    imgSlide: document.querySelectorAll("#slide ul li"),
    avanzar: document.querySelector("#slide #avanzar"),
    retroceder: document.querySelector("#slide #retroceder"),
    velocidadSlide: 3000,
    formatearLoop: false
}

