(function () {
    var sammyApp = Sammy('#content', function () {
        this.get('#/', homeController.all);
        this.get('#/auth', authController.all);
        this.get('#/panel', panelController.all);
    });

    sammyApp.run('#/panel');

    $(window).on('beforeunload', function () {
        sessionStorage.setItem('lala', 'aa');
        localStorage.removeItem('signed-in-user-username');
        localStorage.removeItem('signed-in-user-auth-key');
        localStorage.removeItem('signed-in-user-bool');
    });
}());