var data = (function () {

    var serverUrl = 'http://just-diy.azurewebsites.net/';

    function register(user) {
        var reqUser = {
            Email: user.username,
            Password: user.password,
            ConfirmPassword: user.password
        };

        return jsonRequester.post(serverUrl + 'api/Account/Register', { data: reqUser })
            .then(function (resp) {
                toastr.success('Are you the six fingered man?', 'Inigo Montoya');
            })
            .catch(function (resp) {
                toastr.error('Just reenter everything... (hint: If the passwords match, try with different email)', 'You\'ve messed up!');
            });
    }

    function login(user, context) {
        jsonRequester.token(serverUrl + 'Token', {
            Username: user.username,
            Password: user.password,
            grant_type: 'password'
        }, context);
    }

    return {
        register: register,
        login: login
    }
}());