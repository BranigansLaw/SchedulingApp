'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers', ['app.services'])

    // Path: /
    .controller('HomeCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'AngularJS SPA Template for Visual Studio';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])

    // Path: /about
    .controller('AboutCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'AngularJS SPA | About';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])

    // Path: /login
    .controller('LoginCtrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'AngularJS SPA | Sign In';
        // TODO: Authorize a user
        $scope.login = function () {
            $location.path('/');
            return false;
        };
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }])

    // Path: /
    .controller('CreateEvent', ['$scope', 'SchedulingAppService', function ($scope, SchedulingAppService) {
        this.toCreate = {
            Title: "",
            Description: "",
            Times: [],
            Attendees: [],
            Locations: []
        };

        this.addAttendee = function (name, email) {
            this.toCreate.Attendees.push({
                Name: name,
                Email: email
            });
        };

        this.formatDate = function (javascriptDate) {
            return javascriptDate;
        };

        this.addDate = function (date) {
            this.toCreate.Times.push({
                Value: date
            });
        };

        this.addLocation = function (name, address) {
            this.toCreate.Locations.push({
                Name: name,
                Address: address
            });
        };

        this.save = function () {
            SchedulingAppService.CreateEvent(this.toCreate);
        };
    }])

    // Path: /error/404
    .controller('Error404Ctrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'Error 404: Page Not Found';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }]);