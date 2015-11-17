(function() {

  var sammyApp = Sammy('#content', function() {

    this.get('#/', function(context) {
      context.redirect('#/home');
    });

    this.get('#/home', controllers.home.all);
    this.get('#/home/add', controllers.home.add);

    this.get('#/my-project', controllers.myCookie.all);

    this.get('#/users/register', controllers.users.register);
  });

  $(function() {
    sammyApp.run('#/');

    if (data.users.hasUser()) {
      $('#container-sign-in').addClass('hidden');
      $('#btn-sign-out').on('click', function() {
        data.users.signOut()
          .then(function() {
            toastr.success('User signed out!');
            setTimeout(function() {
              document.location = '#/';
              document.location.reload(true);
            }, 1000);
          });
      });
    } else {
      $('#container-sign-out').addClass('hidden');
      $('#btn-sign-in').on('click', function(e) {
        e.preventDefault();
        var user = {
          username: $('#tb-username').val(),
          password: $('#tb-password').val()
        };
        data.users.signIn(user)
          .then(function(user) {
            toastr.success('User signed in!');
            setTimeout(function() {
              document.location = '#/';
              document.location.reload(true);
            }, 1000);
          }, function(err) {
            $('#container-sign-in').trigger("reset");
            toastr.error(err.responseText);
          });
      });
    }
  });
}());
