landPropertiesApp.factory('landPropertiesRepository', function ($http) {
    return {
        getAllLandProperties: function (callback) {
            $http.get('http://localhost/landProperties/api/landproperties/get').success(callback);
        },
        getLandProperty: function (id, callback) {
            $http({
                url: 'http://localhost/landProperties/api/landproperties/get',
                method: 'GET',
                params: { id: id }
            }).success(callback);
        },
        saveLandProperty: function (landProperty, callback) {
            $http.post('http://localhost/landProperties/api/landproperties/', landProperty).success(callback);
        },
        deleteLandProperty: function (id, callback) {
            $http({
                url: 'http://localhost/landProperties/api/landproperties/',
                method: 'DELETE',
                params: { id: id }
            }).success(callback);
        }
    };
});

landPropertiesApp.factory('ownersRepository', function ($http) {
    return {
        getAllOwners: function (callback) {
            $http.get('http://localhost/landProperties/api/owners/get').success(callback);
        },
        saveOwner: function (owner, callback) {
            $http.post('http://localhost/landProperties/api/owners/', owner).success(callback);
        },
        getOwner: function (id, callback) {
            $http({
                url: 'http://localhost/landProperties/api/owners/',
                method: 'GET',
                params: { id: id }
            }).success(callback);
        },
        deleteOwner: function (id, successCallback, errorCallback) {
            $http({
                url: 'http://localhost/landProperties/api/owners/',
                method: 'DELETE',
                params: { id: id }
            }).success(successCallback).error(errorCallback);
        }
    };
});

landPropertiesApp.factory('mortgagesRepository', function ($http) {
    return {
        delete: function (id, successCallback) {
            $http({
                url: 'http://localhost/landProperties/api/mortgages/',
                method: 'DELETE',
                params: { id: id }
            }).success(successCallback);
        }
    };
});