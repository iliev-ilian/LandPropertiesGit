var landPropertiesApp = angular.module('landPropertiesApp', ['ngRoute']);

landPropertiesApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
      when("/", { templateUrl: "/landProperties/content/templates/LandProperties.html", controller: "LandPropertiesController" }).
      when("/landProperties/edit/:id", { templateUrl: "/landProperties/content/templates/EditlandProperty.html", controller: "EditLandPropertyController" }).
      when("/landProperties/add", { templateUrl: "/landProperties/content/templates/EditlandProperty.html", controller: "EditLandPropertyController" }).
      when("/owners", { templateUrl: "/landProperties/content/templates/Owners.html", controller: "OwnersController" }).
      when("/owners/edit/:id", { templateUrl: "/landProperties/content/templates/EditOwner.html", controller: "EditOwnerController" }).
      otherwise({ redirectTo: '/' });
}]);