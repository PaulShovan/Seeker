var tabModule = angular.module('tabsModule', ['ngRoute']);

tabModule.config(function ($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl: '/Questions.html',
            controller: QuestionsCtrl
        })
        .when('/tags', {
            templateUrl: '/Tags.html',
            controller: TagsCtrl
        })
        .when('/users', {
            templateUrl: '/Users.html',
            controller: UsersCtrl
        })
        .when('/badges', {
            templateUrl: '/Badges.html',
            controller: BadgesCtrl
        });
});

function QuestionsCtrl($scope) {
    $scope.message = "Hello";
}

function TagsCtrl($scope) {
    $scope.message = "Hello";
}

function UsersCtrl($scope) {
    $scope.message = "Hello";
}

function BadgesCtrl($scope) {
    $scope.message = "Hello";
}