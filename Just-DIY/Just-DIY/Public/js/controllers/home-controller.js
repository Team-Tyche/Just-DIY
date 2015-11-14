var homeController = (function($){
    function show(context) {

        templates.get('home')
            .then(function(template) {
                console.log('so there IS life in this whole thing');
                $('.button-collapse').sideNav();
                $('.parallax').parallax();
                
                context.$element().html(template());
            });
    }

    return {
        show: show
    }
}(jQuery));