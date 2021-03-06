﻿'use strict';

// Demonstrate how to register services
// In this case it is a simple value service.
angular.module('app.services', [])
    .value('version', '0.1')
    .factory("SchedulingAppService", function ($http) {
        return {
            CreateEvent: function (event) {
                return $http.post('/SchedulingApp.svc/Events', event);
            }
        };
    });