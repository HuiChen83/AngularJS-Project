(function () {
    'use strict';

    angular.module('app', ['ngRoute']);

    angular.module('app', ['ngRoute'])
        .controller('FareCalculateController', function ($scope, TripService) {

            $scope.SubmitforCalc = function () {
                TripService.CalculateFare($scope.trip);
            }
        })
        .factory('TripService', ['$http', function ($http) {
            var fn = {};
            fn.CalculateFare = function (trip) {
                $http.post('/Trip/FareCalculate', trip)
                    .then(function (response) {
                        var resultField = angular.element(document.querySelector('#Result'));
                        resultField.val(response.data);
                    },
                        function (response) {
                            var resultField = angular.element(document.querySelector('#Result'));
                            resultField.val(response.data);
                        })
            }
            return fn;
        }])
})();