(function () {
    var sammyApp = Sammy('#content', function () {

        this.get('#/', homeController.all);
        this.get('#/auth', authController.all);
        this.get('#/panel', panelController.all);
    });

    sammyApp.run('#/panel');
}());