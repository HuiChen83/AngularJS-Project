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
                            resultField.val('HTTP Request Failed ' + response.data);
                        })
            }
            return fn;
        }])

        .directive('integer', function () {
            return {
                require: 'ngModel',
                restrict: 'A',
                link: function (scope, element, attrs, ctrl) {
                    ctrl.$parsers.push(function (input) {
                        if (input == undefined) return ''
                        var inputNumber = input.toString().replace(/[^0-9]/g, '');
                        if (inputNumber != input) {
                            ctrl.$setViewValue(inputNumber);
                            ctrl.$render();
                        }
                        return inputNumber;
                    });
                }
            };
        })
})();