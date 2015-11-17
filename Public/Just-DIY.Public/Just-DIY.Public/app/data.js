var data = (function () {
    function register(user) {
        var reqUser = {
            Email: user.username,
            Password: user.password,
            ConfirmPassword: user.password
        };

        return jsonRequester.post('http://localhost:29004/api/Account/Register', { data: reqUser })
            .then(function (resp) {
                toastr.success('Are you the six fingered man?', 'Inigo Montoya');
            })
            .catch(function (resp) {
                var error = JSON.parse(resp.responseText);
                toastr.error(error.ModelState[''][1]);
            });
    }

    function login(user) {
        jsonRequester.token('http://localhost:29004/Token', {
            Username: user.username,
            Password: user.password,
            grant_type: 'password'
        });
    }

    return {
        register: register,
        login: login
    }
}());