var authController = function () {

    function all(context) {
        templates.get('auth')
          .then(function (content) {
              context.$element().html(content);
          });
    }

    return {
        all: all
    };
}();