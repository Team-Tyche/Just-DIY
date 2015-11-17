var authController = function () {

    function all(context) {
        templates.get('auth')
          .then(function (content) {
              context.$element().html(content);

              $('#cpa-submit').click(function () {
                  var user = {
                      username: $('#login_id').val(),
                      password: $('#pin_id').val(),
                      confirmPassword: $('#verify_pin_id').val()
                  };

                  data.register(user);
              });


              $('#cpa-login').click(function () {
                  var user = {
                      username: $('#login_id').val(),
                      password: $('#pin_id').val()
                  };

                  data.login(user);
              });
          });
    }

    return {
        all: all
    };
}();