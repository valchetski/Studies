angular.module('NewMessageApp', []).controller('NewMessageController', ['$scope',
    function ($scope) {

        $scope.ClickSubmit = function (event) {
            //$scope.ValidateNewMessage();
            //$scope.ValidatePassword();
            //if ($scope.IsWrongNewMessage || $scope.IsWrongPassword) {
            //    event.preventDefault();
            //}
        }

        $scope.CancelSubmit = function () {
            window.location = "/";
        }
    }
])