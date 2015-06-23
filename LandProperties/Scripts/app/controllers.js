landPropertiesApp.controller("LandPropertiesController", function ($scope, landPropertiesRepository) {
    fillLandProperties();
    function fillLandProperties() {
        landPropertiesRepository.getAllLandProperties(function (result) {
            $scope.landProperties = result;
        })
    };

    $scope.delete = function (id) {
        landPropertiesRepository.deleteLandProperty(id, function () {
            fillLandProperties();
        });
    };
});

landPropertiesApp.controller("EditLandPropertyController", function ($scope, $routeParams, $location,
                    landPropertiesRepository, ownersRepository, mortgagesRepository) {
    fillData();

    function fillData() {
        if ($routeParams.isEditMode)
            fillLandProperty();

        fillAllOwners();
    };

    function fillLandProperty() {
        landPropertiesRepository.getLandProperty($routeParams.id, function (result) {
            $scope.currLandProperty = result;
        });
    };

    function fillAllOwners() {
        ownersRepository.getAllOwners(function (result) {
            $scope.owners = result;
        });
    };

    $scope.save = function (landProperty) {
        landPropertiesRepository.saveLandProperty(landProperty, function (result) {
            if ($routeParams.isEditMode)
                $scope.showSaveSucceessMessage = true;
            else
                $location.path('/')
        });
    };

    $scope.showNewMortgageFeature = function () {
        $scope.isAddNewMortgagePanelVisible = true;
        $scope.currAddedMortgage = new Object();
    },

    $scope.addNewMortgage = function () {
        //Adding the mortgage in the mortgages collection in the view and on save they will be inserted in DB
        $scope.currLandProperty.Mortgages = $scope.currLandProperty.Mortgages || new Array();
        $scope.currLandProperty.Mortgages.push($scope.currAddedMortgage);
        $scope.isAddNewMortgagePanelVisible = false;
    };

    $scope.deleteMortgage = function (id) {
        //Delete mortgages only in the view and on save they will be deleted
        for (var i = 0; i < $scope.currLandProperty.Mortgages.length; i++) {
            if ($scope.currLandProperty.Mortgages[i].ID == id) {
                $scope.currLandProperty.Mortgages.splice(i, 1);
                break;
            }
        }

        //Could be used to delete mortgages immediately - implementation choise
        //mortgagesRepository.delete(id, function () {
        //    fillLandProperty();
        //});
    };
});

landPropertiesApp.controller("OwnersController", function ($scope, $routeParams, ownersRepository) {
    fillOwners();
    function fillOwners() {
        ownersRepository.getAllOwners(function (result) {
            $scope.owners = result;
        });
    };

    $scope.showAddOwnerFeature = function () {
        $scope.isAddNewOwnerVisible = true;
        $scope.newOwner = new Object();
    };

    $scope.addOwner = function () {
        $scope.isAddNewOwnerVisible = false;
        ownersRepository.saveOwner($scope.newOwner, function (owner) {
            $scope.owners.push(owner);
        });
    };

    $scope.deleteOwner = function (owner) {
        ownersRepository.deleteOwner(owner.ID, function () {
            for (var i = 0; i < $scope.owners.length; i++) {
                if ($scope.owners[i].ID == owner.ID) {
                    $scope.owners.splice(i, 1);
                    break;
                }
            }
        }, function (err) {
            $scope.showDeleteErrorMessage = true;
        });
    };
});

landPropertiesApp.controller("EditOwnerController", function ($scope, $routeParams, $location, ownersRepository) {
    getOwner();
    function getOwner() {
        ownersRepository.getOwner($routeParams.id, function (result) {
            $scope.owner = result;
        });
    };

    $scope.save = function () {
        ownersRepository.saveOwner($scope.owner, function () {
            $location.path('/owners');
        });
    };
});