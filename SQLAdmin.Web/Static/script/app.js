﻿(function () {
    function session_interceptor($q, session, messager) {
        var _interceptor = {
            request: function (config) {
                var dbConfig = session.get("config");
                if (dbConfig != null) {
                    config.headers["databaseConfig"] = JSON.stringify(dbConfig);
                }
                messager.loading();
                return config;
            },
            responseError:function(config)
            {
                messager.error("一个错误发生。");
                return config;
            },
            response: function (config) {
                messager.loading(true);
                if (config.data && config.data.IsSuccess == undefined)
                {
                    try
                    {
                        config.data = JSON.parse(config.data);
                    }
                    catch(e)
                    {
                        console.log(e);
                    }
                }
                if (config.data.IsSuccess != undefined && !config.data.IsSuccess)
                {
                    messager.error(config.data.Messuige);
                }
                else
                {
                    return config;
                }
            }
        }

        return _interceptor;
    }

    angular.module("admin", ['sqladmin']).factory("session.interceptor", ["$q", "session.service", "messager.service", session_interceptor]);

    angular.module("admin").config(function ($httpProvider) {
        $httpProvider.interceptors.push("session.interceptor");
        document.oncontextmenu = function () { return false; }
    });
    
})();