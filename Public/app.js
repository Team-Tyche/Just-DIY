(function () {

    var sammyApp = Sammy('#content', function () {

        this.get('#/', function (context) {
            context.redirect('#/home');
        });

        this.get('#/home', homeController.show);

        this.get('#/register', function (context) {

        });
    });

    $(function () {
        sammyApp.run('#/');
    });
}());