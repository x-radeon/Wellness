// selfController.js

(function () {
    "use strict";

    angular.module("app-self")
        .controller("selfController", selfController);

    function selfController($http, $scope) {
        var vm = this;

        vm.self = [];
        vm.metrics = [];
        vm.newMetric = {};
        vm.selected = {};
        vm.errorMessage = "";
        vm.isBusy = true;

        vm.bodyTypes = [
            { value: 'Standard', text: 'Standard' },
            { value: 'Athletic', text: 'Athletic' }
        ];

        vm.genders = [
            { value: 'Male', text: 'Male' },
            { value: 'Female', text: 'Female' }
        ];

        vm.getSelf = function () {
            $http.get("/api/self")
                .then(function (response) {
                    //worky
                    angular.copy(response.data, vm.self);

                }, function (error) {
                    //no worky
                    vm.errorMessage = "Failed to load self data!: " + error;
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        };

        vm.getMetrics = function () {
            $http.get("/api/self/metrics")
                .then(function (response) {
                    //worky
                    angular.copy(response.data, vm.metrics);

                }, function (error) {
                    //no worky
                    vm.errorMessage = "Failed to load metric data!: " + error;
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        };

        vm.addMetric = function (){
            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post("/api/self/metrics", vm.newMetric)
                .then(function (response) {
                    //worky
                    vm.metrics.push(response.data);
                    vm.newMetric = {};
                }, function () {
                    //no worky
                    vm.errorMessage = "Failed to save new metrics: " + error;
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        }

        vm.deleteMetric = function (id) {
            vm.isBusy = true;
            vm.errorMessage = "";

            $http.delete("/api/self/metric/" + id)
                .then(function () {
                    vm.getMetrics();
                }, function (error) {
                    //no worky
                    vm.errorMessage = "Failed to delete metric!: " + error;
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        };

        vm.editMetric = function (metric) {
            vm.selected = angular.copy(metric);
        };

        $scope.labels = ["January", "February", "March", "April", "May", "June", "July"];
        $scope.series = ['Weight', 'Fat Mass'];
        $scope.data = [
          [207, 205, 204, 206, 202, 198, 195],
          [47, 50, 49, 53, 51, 45, 51]
        ];
        $scope.onClick = function (points, evt) {
            console.log(points, evt);
        };

        vm.getSelf();
        vm.getMetrics();
        
    };
})();