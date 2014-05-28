var module = angular.module('myTestApp', []);

module.controller('TestCtrl', function ($scope, $http) {
    $http.get('/api/Test').success(function (infos) {
        $scope.results = infos;
    })
    .error(function () {
        alert("Something wrong happened!!!");
    });
});