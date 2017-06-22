angular.module('LoginApp', []).controller('LoginController', ['$scope',
    function ($scope) {
        $scope.IsWrongLogin = true;
        $scope.IsWrongPassword = true;

        $scope.lModel = {}

        $scope.ValidateLogin = function () {
            this.IsWrongLogin = this.lModel.Login === undefined || this.lModel.Login.length === 0;
            if (this.IsWrongLogin) {
                SetError('lModel.Login', 'Input your Login');
            } else {
                ResetError('lModel.Login');
            }
        }

        $scope.ValidatePassword = function () {
            this.IsWrongPassword = this.lModel.Password === undefined || this.lModel.Password.length < 6;
            if (this.IsWrongPassword) {
                SetError('lModel.Password', 'Password should be at least 6 characters');
            } else {
                ResetError('lModel.Password');
                if (this.IsWrongConfirmPassword === false) {
                    $scope.ValidateConfirmPassword();
                }
            }
        }

        $scope.ClickSubmit = function (event) {
            $scope.ValidateLogin();
            $scope.ValidatePassword();
            if ($scope.IsWrongLogin || $scope.IsWrongPassword) {
                event.preventDefault();
            }
        }
    }
])