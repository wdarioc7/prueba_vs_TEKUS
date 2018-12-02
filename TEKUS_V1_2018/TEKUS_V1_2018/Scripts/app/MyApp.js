var Myapp = angular.module('Myapp', []);
Myapp.controller("myCtrl", function ($scope, $http) {
    debugger; 

    $scope.GetAllData = function () {
        $http({
            method: "GET",
            url: "/TBL_TEKUS_CLIENTES/Get_AllClientes",
            data: $scope.clientes
        }).then(function (response) {
            $scope.clientes = response.data;
        }, function () {
            alert("Ocurrio un error");
        })
    };  


}
);