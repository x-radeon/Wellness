// selfController.js

(function () {
    "use strict";

    angular.module("app-self")
        .controller("selfController", selfController);

    function selfController($http, $scope) {
        var vm = this;

        vm.self = [];
        vm.metrics = [];

        //chart.js stuff
        $scope.weightChartType = 'Bar'
        $scope.weightChartSeries = ['Weight (Lbs)'];
        $scope.weightChartLabels = [];
        $scope.weightChartData = [[]];

        $scope.BMRChartType = 'Line'
        $scope.BMRChartSeries = ['Basal Metabolic Rate'];
        $scope.BMRChartLabels = [];
        $scope.BMRChartData = [[]];

        $scope.MFBChartType = 'Bar'
        $scope.MFBChartSeries = ['Muscle', 'Fat', 'Bone'];
        $scope.MFBChartLabels = [];
        $scope.MFBChartData = [[], [], []];

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

        vm.toggleWeightChart = function () {
            $scope.weightChartType = $scope.weightChartType === 'Bar' ?
              'Line' : 'Bar';
        };

        vm.toggleMFBChart = function () {
            $scope.MFBChartType = $scope.MFBChartType === 'Bar' ?
              'Radar' : 'Bar';
        };

        vm.toggleBMRChart = function () {
            $scope.BMRChartType = $scope.BMRChartType === 'Line' ?
              'Bar' : 'Line';
        };

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
                    $scope.weightChartLabels = [];
                    $scope.weightChartData = [[]];
                    $scope.MFBChartLabels = [];
                    $scope.MFBChartData = [[], [], []];
                    $scope.BMRChartLabels = [];
                    $scope.BMRChartData = [[]];

                    angular.copy(response.data, vm.metrics);

                    if (vm.metrics.length < 11)
                    {
                        for (var i = 0; i < vm.metrics.length; i++) {
                            $scope.weightChartData[0].push(vm.metrics[i].weight);

                            $scope.MFBChartData[0].push(vm.metrics[i].muscleMass);
                            $scope.MFBChartData[1].push(vm.metrics[i].fatMass);
                            $scope.MFBChartData[2].push(vm.self.boneMass);

                            $scope.BMRChartData[0].push(vm.metrics[i].basalMetabolicRate);

                            var date = new Date(vm.metrics[i].created);
                            date = date.getFullYear() + '/' + (date.getMonth() + 1) + '/' + date.getDate();


                            $scope.weightChartLabels.push(date);
                            $scope.MFBChartLabels.push(date);
                            $scope.BMRChartLabels.push(date);
                        };
                    }
                    else
                    {
                        for (var i = 0; i < 10; i++) {
                            $scope.weightChartData[0].push(vm.metrics[i].weight);

                            $scope.MFBChartData[0].push(vm.metrics[i].muscleMass);
                            $scope.MFBChartData[1].push(vm.metrics[i].fatMass);
                            $scope.MFBChartData[2].push(vm.self.boneMass);

                            $scope.BMRChartData[0].push(vm.metrics[i].basalMetabolicRate);

                            var date = new Date(vm.metrics[i].created);
                            date = date.getFullYear() + '/' + (date.getMonth() + 1) + '/' + date.getDate();


                            $scope.weightChartLabels.push(date);
                            $scope.MFBChartLabels.push(date);
                            $scope.BMRChartLabels.push(date);
                        };
                    }

                    $scope.weightChartLabels.reverse();
                    $scope.MFBChartLabels.reverse();
                    $scope.BMRChartLabels.reverse();

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
                    window.location = "#/";
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

        vm.getSelf();
        vm.getMetrics();
        
    };
})();
