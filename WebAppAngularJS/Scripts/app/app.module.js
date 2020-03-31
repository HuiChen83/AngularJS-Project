(function () {
    'use strict';

    angular.module('app', ['ngRoute']);

    angular.module('app', ['ngRoute'])
        .controller('FareCalculateController', function ($scope, TripService) {

            $scope.SubmitforCalc = function () {
                TripService.CalculateFare($scope.trip)  //Handle promise and return calculation result to ng-model in html
                    .then(function (response) {
                        $scope.result = '$' + response.data;
                    },
                    function (error) {
                        $scope.result = 'Http Request Failed.'   //Or give an Alert?
                    });
            }

            $scope.ClearResult = function () {
                $scope.result = '';
            }

            $scope.ResetUserInputs = function () {
                $scope.trip.MinsAbvSpeed = '0';
                $scope.trip.MilesBlwSpeed = '0';
                $scope.trip.DateTime = '';
                $scope.result = '';
            }
        })

        .factory('TripService', ['$http', function ($http) {    //Http post to server controller
            var fn = {};
            fn.CalculateFare = function (trip) {
                return $http.post('/Trip/FareCalculate', trip); //Return promise
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
                        var inputNumber = input.toString()
                            .replace(/[^0-9]/g, '') //number only
                            .replace(/^[0\.]+/, '');    //remove leading zeros
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