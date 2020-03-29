(function () {
    'use strict';

    angular.module('app')
        .config(['$routeProvider', function ($routeProvider) {
            $routeProvider
                .when('/', {
                    templateUrl: 'Home/Home',
                    controller: 'FareCalculateController'
                })
                .when('/Page1', {
                    templateUrl: 'Home/Page1'
                })
        }])
})();