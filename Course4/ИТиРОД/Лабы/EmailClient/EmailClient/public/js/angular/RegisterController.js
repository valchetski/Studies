angular.module('RegisterApp', []).controller('RegisterController', ['$scope',
    function($scope) {
        $scope.IsWrongLogin = true;
        $scope.IsWrongPassword = true;
        $scope.ArePasswordsNotEqual = true;
        $scope.IsWrongConfirmPassword = true;

        $scope.rModel = {}

        $scope.ValidateLogin = function () {
            this.IsWrongLogin = this.rModel.Login === undefined || this.rModel.Login.length === 0;
            if (this.IsWrongLogin) {
                SetError('rModel.Login', 'Input your Login');
            } else {
                ResetError('rModel.Login');
            }
        }

        $scope.ValidatePassword = function () {
            this.IsWrongPassword = this.rModel.Password === undefined || this.rModel.Password.length < 6;
            if (this.IsWrongPassword) {
                SetError('rModel.Password', 'Password should be at least 6 characters');
            } else {
                ResetError('rModel.Password');
                if (this.IsWrongConfirmPassword === false) {
                    $scope.ValidateConfirmPassword();
                }
            }
        }

        $scope.ValidateConfirmPassword = function () {
            this.IsWrongConfirmPassword = this.rModel.ConfirmPassword === undefined || this.rModel.ConfirmPassword.length < 6;
            if (this.IsWrongConfirmPassword) {
                SetError('rModel.ConfirmPassword', 'Password should be at least 6 characters');
            } else {
                this.ArePasswordsNotEqual = this.rModel.ConfirmPassword !== this.rModel.Password;
                if (this.ArePasswordsNotEqual) {
                    SetError('rModel.ConfirmPassword', 'Passwords are not equal');
                } else {
                    ResetError('rModel.ConfirmPassword');
                }
            }
        }

        $scope.ClickSubmit = function(event) {
            $scope.ValidateLogin();
            $scope.ValidatePassword();
            $scope.ValidateConfirmPassword();
            if ($scope.IsWrongLogin || $scope.IsWrongPassword || $scope.IsWrongConfirmPassword || $scope.ArePasswordsNotEqual) {
                event.preventDefault();
            } 
        }
    }
])