//module sherlockApp
(function () {
    'use strict';

    angular.module('sherlockApp', [
        'ngTouch',
        'ngResource',
        'ngMaterial',
        'ngMessages',
        'ui.router',
        'LocalStorageModule',
        'nvd3'
    ]);
})();

//constants
(function () {
    'use strict';

    angular
        .module('sherlockApp')
        .constant('sherlockConfig', {
            appName: 'Sherlock',
            toolbarLoc: 'partials/_ToolbarButton.html',
            tempHomeLoc: 'partials/_Home.html',
            tempLoginLoc: 'partials/_Login.html',
            sideNavId: 'left',
            hubLeadStatusMethod: 'broadcastMessage',
            hubClassName: 'autoUpdate',
            hubServerUrl: 'http://localhost/sherlockapi/',
            apiCaptureLead: '/sherlockapi/api/sherlock/capturelead'
        })
})();

//configs
(function () {
    'use strict';

    angular.module('sherlockApp')
        .config(function (localStorageServiceProvider) {
            localStorageServiceProvider
                .setStorageCookie(1, '/');
        })
        .config(function ($mdThemingProvider) {
            $mdThemingProvider.theme('default')
                .primaryPalette('grey');
        })
        .config(function ($mdIconProvider) {
            $mdIconProvider
                .icon('kelock', './mimg/ke_lock.svg', 32)
                .icon('loguser', './mimg/user.svg', 32)
                .icon('passkey', './mimg/pas_key4.svg', 32)
                .icon('unlock', './mimg/unlock2.svg', 32)
                .icon('smartphone', './mimg/smart-phone.svg', 32)
                .icon('emailmsg', './mimg/email_msg.svg', 32)
                .icon('zipcode', './mimg/place.svg', 32)
                .icon('moreshow', './mimg/more2.svg', 32)
                .icon('useradd', './mimg/user-add.svg', 32)
                .icon('plussign', './mimg/plus_sign.svg', 32)
                .icon('refresh', './mimg/refresh1.svg', 32)
                .icon('cancelbtn', './mimg/cancel_btn.svg', 32)
                .icon('refresh', './mimg/refresh1.svg', 32)
                .icon('menuitem', './mimg/th-menu.svg', 32)
                .icon('logout', './mimg/power_btn2.svg', 32)
                .icon('login', './mimg/login2.svg', 32)
                .icon('nsearch', './mimg/search.svg', 32)
                .icon('advsearch', './mimg/zoom_in.svg', 32)
                .icon('analytics', './mimg/Analytics.svg', 32)
                .icon('home', './mimg/ic_home.svg', 32)
                .icon('history', './mimg/history.svg', 32)
                .icon('play', './mimg/play_circle.svg', 32)
                .icon('pause', './mimg/pause_circle.svg', 32)
                .icon('avgtime', './mimg/av_timer.svg', 32)
                .icon('blocklist', './mimg/block.svg', 32);
        })
        .run(function ($http, $templateCache) {
            var urls = [
                './mimg/ke_lock.svg',
                './mimg/user.svg',
                './mimg/pas_key4.svg',
                './mimg/unlock2.svg',
                './mimg/email_msg.svg',
                './mimg/place.svg',
                './mimg/more2.svg',
                './mimg/user-add.svg',
                './mimg/plus_sign.svg',
                './mimg/cancel_btn.svg',
                './mimg/refresh1.svg',
                './mimg/th-menu.svg',
                './mimg/power_btn2.svg',
                './mimg/login2.svg',
                './mimg/search.svg',
                './mimg/zoom_in.svg',
                './mimg/Analytics.svg',
                './mimg/ic_home.svg',
                './mimg/history.svg',
                './mimg/play_circle.svg',
                './mimg/pause_circle.svg',
                './mimg/av_timer.svg',
                './mimg/block.svg'
            ];
            angular.forEach(urls, function (url) {
                $http.get(url, { cache: $templateCache });
            });
        })
        .config(["$locationProvider", function ($locationProvider) {
            //$locationProvider.html5Mode(true);
        }])
        .config(function ($stateProvider, $urlRouterProvider, sherlockConfig) {
            $urlRouterProvider.otherwise("/login");
            $stateProvider
                .state('home', {
                    url: "/home",
                    controller: 'HomeCtrl as home',
                    templateUrl: sherlockConfig.tempHomeLoc
                })
                .state('login', {
                    url: "/login",
                    controller: 'LoginCtrl as login',
                    templateUrl: sherlockConfig.tempLoginLoc
                })
        })
})();

//signalRHubProxy factory
(function () {
    'use strict';

    angular
        .module('sherlockApp')
        .factory('signalRHubProxy', signalrproxyfn);

    function signalrproxyfn($rootScope, sherlockConfig) {
        function signalRHubProxyFactory(serverUrl, hubName) {
            //$.connection.hub.url = '/SherlockAPI/signalr';
            var connection = $.hubConnection(serverUrl);
            var proxy = connection.createHubProxy(hubName);
            connection.start().done(function () { });

            return {
                on: function (eventName, callback) {
                    console.log(eventName);
                    proxy.on(eventName, function (result) {
                        //$rootScope.$apply();
                        $rootScope.$emit(sherlockConfig.hubLeadStatusMethod, result);
                    });
                },
                off: function (eventName, callback) {
                    proxy.off(eventName, function (result) {
                        $rootScope.$apply(function () {
                            if (callback) {
                                callback(result);
                            }
                        });
                    });
                },
                invoke: function (methodName, callback) {
                    proxy.invoke(methodName)
                        .done(function (result) {
                            $rootScope.$apply(function () {
                                if (callback) {
                                    callback(result);
                                }
                            });
                        });
                },
                connection: connection
            };
        };

        return signalRHubProxyFactory;
    }
})();

//sherlockCtrl
(function () {
    'use strict';

    angular
        .module('sherlockApp')
        .controller('sherlockCtrl', controller);

    //controller.$inject = ['$location'];

    function controller($mdSidenav, sherlockConfig, signalRHubProxy) {
        /* jshint validthis:true */
        var vm = this;
        vm.templateUrlToolbar = sherlockConfig.toolbarLoc;
        vm.title = sherlockConfig.appName;

        vm.toggleLeft = buildToggler(sherlockConfig.sideNavId);
        function buildToggler(navID) {
            return function () {
                return $mdSidenav(navID).toggle();
            }
        };

        var clientPushHubProxy = signalRHubProxy(sherlockConfig.hubServerUrl, sherlockConfig.hubClassName);
        clientPushHubProxy.on(sherlockConfig.hubLeadStatusMethod);

    }
})();

//HomeCtrl
(function () {
    'use strict';

    angular
        .module('sherlockApp')
        .controller('HomeCtrl', controller);

    //controller.$inject = ['$location'];

    function controller($http, $rootScope, $scope, sherlockConfig) {

        var vm = this;
        vm.leadStatus = [];
        vm.productName = 'Mortgage';
        vm.data = { cb5: true };
        var interval = 30000;
        vm.liveRun = true;
        vm.onLiveDataChange = function (state) {
            vm.liveRun = state;
        }

        var startHome = function () {
            $http.get(sherlockConfig.apiCaptureLead).success(function (data, status) {
            });
        };

        angular.element(document).ready(function () {
            startHome();
        });

        $rootScope.$on(sherlockConfig.hubLeadStatusMethod, function (e, msg) {
            //console.log(msg);
            $rootScope.$apply(function () {
                //vm.leadStatus.push(msg);
                updateLeadStage(msg);
            });
        });

        var updateLeadStage = function (leadObject) {
            if (vm.leadStatus.length > 0) {
                console.log(leadObject.LeadId);
                var matchFound = false;
                for (var i = 0; i < vm.leadStatus.length; i++) {
                    if (vm.leadStatus[i].LeadId == leadObject.LeadId) {
                        vm.leadStatus[i].LeadStage = leadObject.LeadStage;
                        matchFound = true;
                        break;
                    }
                }
                if (!matchFound)
                    vm.leadStatus.push(leadObject);
                console.log(matchFound);
            }
            else {
                vm.leadStatus.push(leadObject);
                console.log(leadObject.LeadId);
            }
        }

        vm.optionsPie = {
            chart: {
                type: 'pieChart',
                height: 300,
                x: function (d) { return d.key; },
                y: function (d) { return d.y; },
                showLabels: true,
                duration: 500,
                labelThreshold: 0.01,
                labelSunbeamLayout: true,
                legend: {
                    margin: {
                        top: 5,
                        right: 35,
                        bottom: 5,
                        left: 0
                    }
                }
            }
        };

        vm.dataPie = [
            {
                key: "New",
                y: 5
            },
            {
                key: "Transferred",
                y: 2
            },
            {
                key: "Error",
                y: 9
            },
            {
                key: "Not Transferred",
                y: 7
            }
        ];

        vm.optionsStack = {
            chart: {
                type: 'stackedAreaChart',
                height: 300,
                margin: {
                    top: 5,
                    right: 25,
                    bottom: 20,
                    left: 10
                },
                x: function (d) { return d[0]; },
                y: function (d) { return d[1]; },
                useVoronoi: false,
                clipEdge: true,
                transitionDuration: 500,
                useInteractiveGuideline: true,
                xAxis: {
                    showMaxMin: false,
                    tickFormat: function (d) {
                        return d3.time.format('%x')(new Date(d))
                    }
                },
                yAxis: {

                }
            }
        };

        var date1 = new Date("01-Nov-2015");
        date1 = date1.getTime();
        var date2 = new Date("02-Nov-2015");
        date2 = date2.getTime();
        var date3 = new Date("03-Nov-2015");
        date3 = date3.getTime();
        var date4 = new Date("04-Nov-2015");
        date4 = date4.getTime();
        var date5 = new Date("05-Nov-2015");
        date5 = date5.getTime();
        var date6 = new Date("06-Nov-2015");
        date6 = date6.getTime();
        var date7 = new Date("07-Nov-2015");
        date7 = date7.getTime();
        var date8 = new Date("08-Nov-2015");
        date8 = date8.getTime();
        var date9 = new Date("09-Nov-2015");
        date9 = date9.getTime();

        vm.dataStack = [
            {
                "key": "Error",
                "values": [[date1, 2], [date2, 3], [date3, 2], [date4, 5], [date5, 1], [date6, 3], [date7, 3], [date8, 4], [date9, 2]]
            },

            {
                "key": "Transferred",
                "values": [[date1, 17], [date2, 14], [date3, 10], [date4, 20], [date5, 17], [date6, 23], [date7, 13], [date8, 14], [date9, 20]]
            },

            {
                "key": "NotTransferred",
                "values": [[date1, 2], [date2, 4], [date3, 5], [date4, 2], [date5, 4], [date6, 1], [date7, 2], [date8, 5], [date9, 3]]
            },

            {
                "key": "New",
                "values": [[date1, 2], [date2, 1], [date3, 1], [date4, 3], [date5, 2], [date6, 4], [date7, 2], [date8, 1], [date9, 4]]
            }

        ];

        vm.optionsLive = {
            chart: {
                type: 'lineChart',
                height: 300,
                margin: {
                    top: 20,
                    right: 20,
                    bottom: 60,
                    left: 65
                },
                x: function (d) { return d[0]; },
                y: function (d) { return d[1]; },

                color: d3.scale.category10().range(),
                transitionDuration: 300,
                useInteractiveGuideline: true,
                clipVoronoi: false,

                xAxis: {
                    axisLabel: 'X Axis',
                    tickFormat: function (d) {
                        return d3.time.format("%H:%M:%S")(new Date(d))
                    }
                },

                yAxis: {
                    axisLabel: 'Y Axis',
                    tickFormat: function (d) {
                        return d.toFixed(0);
                    },
                    axisLabelDistance: 20
                }
            }
        };

        var date1 = new Date("01-Nov-2015 10:00");
        date1 = date1.getTime();

        var add5Min = function (mlt) {
            return date1 + mlt * 300000
        }

        vm.dataLive = [
            {
                "key": "Error",
                "values": [[date1, 2], [add5Min(2), 3], [add5Min(3), 5], [add5Min(4), 3], [add5Min(5), 1], [add5Min(6), 3], [add5Min(7), 2], [add5Min(8), 4], [add5Min(9), 2]]
            },
             {
                 "key": "Transferred",
                 "values": [[date1, 14], [add5Min(2), 20], [add5Min(3), 17], [add5Min(4), 15], [add5Min(5), 11], [add5Min(6), 15], [add5Min(7), 16], [add5Min(8), 19], [add5Min(9), 16]]
             },
             {
                 "key": "NotTransferred",
                 "values": [[date1, 3], [add5Min(2), 4], [add5Min(3), 2], [add5Min(4), 4], [add5Min(5), 1], [add5Min(6), 2], [add5Min(7), 1], [add5Min(8), 2], [add5Min(9), 1]]
             },
             {
                 "key": "New",
                 "values": [[date1, 1], [add5Min(2), 3], [add5Min(3), 3], [add5Min(4), 2], [add5Min(5), 0], [add5Min(6), 4], [add5Min(7), 2], [add5Min(8), 4], [add5Min(9), 0]]
             }

        ];

        var x = 10;

        setInterval(function () {
            if (!vm.liveRun) return;
            vm.dataLive[0].values.push([add5Min(x), Math.random() * 10 + 1]);
            vm.dataLive[1].values.push([add5Min(x), Math.random() * 10 + 1]);
            vm.dataLive[2].values.push([add5Min(x), Math.random() * 10 + 1]);
            vm.dataLive[3].values.push([add5Min(x), Math.random() * 10 + 1]);
            if (x > 20) {
                vm.dataLive[0].values.shift();
                vm.dataLive[1].values.shift();
                vm.dataLive[2].values.shift();
                vm.dataLive[3].values.shift();
            }
            x++;
            $scope.api.update();
        }, interval);
    }
})();

//LoginCtrl
(function () {
    'use strict';

    angular
        .module('sherlockApp')
        .controller('LoginCtrl', controller);

    //controller.$inject = ['$location'];

    function controller($state) {
        /* jshint validthis:true */
        var vm = this;
        vm.loginFailureMsg = false;
        vm.nouid = false;
        vm.nopwd = false;

        vm.checkLogin = function () {
            var credin = true;
            if (vm.user != undefined) {
                if (vm.user.uid == undefined || vm.user.uid == '') {
                    self.nouid = true;
                    credin = false;
                }
                if (vm.user.upwd == undefined || vm.user.upwd == '') {
                    self.nopwd = true;
                    credin = false;
                }
                if (credin) {
                    if (vm.user.uid == 'sherlock' && vm.user.upwd == 'zxcvbnm') {
                        //localStorageService.set('loginjd', '123243');
                        $state.go('home');
                    } else
                        vm.loginFailureMsg = true;
                }
            }
            else {
                vm.nouid = true;
                vm.nopwd = true;
            }
        };
    }
})();

