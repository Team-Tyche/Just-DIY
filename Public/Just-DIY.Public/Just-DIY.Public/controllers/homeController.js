var homeController = function () {

    function all(context) {
        templates.get('home')
          .then(function (content) {
              context.$element().html(content);
          });
    }

    return {
        all: all
    };
}();