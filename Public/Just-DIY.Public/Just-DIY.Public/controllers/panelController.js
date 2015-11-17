var panelController = function () {

    function all(context) {
        templates.get('panel')
          .then(function (content) {
              context.$element().html(content);
          });
    }

    return {
        all: all
    };
}();