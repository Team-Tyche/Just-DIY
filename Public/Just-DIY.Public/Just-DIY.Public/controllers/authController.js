var authController = function () {

    function all(context) {
        if (localStorage.getItem('signed-in-user-bool')) {
            context.redirect('#/panel');
            return;
        }

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

                  data.login(user, context);
              });
          });
    }

    return {
        all: all
    };
}();