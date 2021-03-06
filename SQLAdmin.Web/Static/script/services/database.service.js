﻿(function () {
    function database_service($http, $q) {
        function _getDatabases() {
            var deferred = $q.defer();
            $http.get("/Database/GetDatabases").then(function (res) {
                deferred.resolve(res.data);
            });
            return deferred.promise;
        }

        function _getTables(tree) {
            var deferred = $q.defer();
            $http.post("/Database/GetTables", { databaseName: tree.Name }).then(function (res) {
                if (!tree.Children) {
                    tree.Children = [];
                }
                for (var i in res.data) {
                    tree.Children.push({ Id: res.data[i].Id, Name: res.data[i].Name, Fullname: res.data[i].Fullname });
                }
                deferred.resolve(tree);
            })
            return deferred.promise;
        }

        function _updateTree(tree, id, newTree) {
            if (tree.Id && tree.Id == id) {
                tree = newTree;
            }
            if (tree.Children) {
                for (var i in tree.Children) {
                    this._UpdateTree(tree.Children[i], id, newTree);
                }
            }
        }

        function _deleteDatabase(dbName) {
            var defarred = $q.defer();
            $http.post("/Database/DeleteDatabase", { databaseName: dbName }).then(function (res) {
                defarred.resolve(res);
            });
            return defarred.promise();
        }

        return {
            getDatabases: _getDatabases,
            getTables: _getTables,
            updateTree: _updateTree,
            deleteDatabase: _deleteDatabase
        }
    }

    angular.module("admin").factory('database.service', ["$http", "$q", database_service]);
})();