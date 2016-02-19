// app-self.js

(function () {
    "use strict";

    angular.module("app-self", ["simpleControls", "ngRoute", "xeditable", "chart.js"])
        .config(function ($routeProvider) {

            $routeProvider.when("/", {
                controller: "selfController",
                controllerAs: "vm",
                templateUrl: "/views/selfView.html"
            });

            $routeProvider.when("/edit", {
                controller: "selfController",
                controllerAs: "vm",
                templateUrl: "/views/selfEditorView.html"
            });

            $routeProvider.when("/metric", {
                controller: "selfController",
                controllerAs: "vm",
                templateUrl: "/views/selfMetricView.html"
            });

            $routeProvider.otherwise({ redirectTo: "/" });

        });

})();