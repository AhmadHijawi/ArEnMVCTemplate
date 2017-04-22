(function () {

    window.app.controller("alertsCtrl", ["$scope", '$rootScope', "$http", function ($scope, $rootScope, $http) {

        var apiUrl = "/api/Common";

        $scope.alerts = new Array();

        $scope.$on(window.alertBroadcastName, function (event, data) {

            var _typeTxt;
            switch (data.type) {
                case 2: {
                    _typeTxt = 'success';
                    break;
                }
                case 3: {
                    _typeTxt = 'warning';
                    break;
                }
                case 4: {
                    _typeTxt = 'danger';
                    break;
                }
                default: {
                    _typeTxt = 'info';
                }
            }

            var receivedMessage = {
                message: data.message,
                typeTxt: _typeTxt
            }

            $scope.alerts.push(receivedMessage)

        });

        $scope.testError = function (testMessage, testType) {
            $rootScope.$broadcast(window.alertBroadcastName, { message: testMessage, type: testType });
        };

        $scope.getAll = function () {

            $http.get(apiUrl).then(function (results) {

                if (results.data != undefined) {
                    for (i = 0; i < results.data.length; i++) {
                        $rootScope.$broadcast(window.alertBroadcastName, { message: results.data[i].Message, type: results.data[i].MessageType });
                    }
                }

            }, function (err) {

                $rootScope.$broadcast(window.alertBroadcastName, { message: err.statusText, type: window.errorCode });

            });

        }

        $scope.getAll();

    }]);

}());