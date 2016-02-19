// app-team.js

(function () {
    "use strict";

    angular.module("app-team", ["simpleControls", "ngRoute", "xeditable", "chart.js"])
        .config(function ($routeProvider) {

            $routeProvider.when("/", {
                controller: "teamController",
                controllerAs: "vm",
                templateUrl: "/views/teamView.html"
            });

            $routeProvider.when("/find", {
                controller: "teamController",
                controllerAs: "vm",
                templateUrl: "/views/findTeamView.html"
            });

            $routeProvider.otherwise({ redirectTo: "/" });

        });

})();