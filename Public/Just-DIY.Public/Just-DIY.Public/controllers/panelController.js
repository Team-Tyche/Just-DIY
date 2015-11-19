var panelController = function () {

    var serverUrl = 'http://just-diy.azurewebsites.net/';

    function all(context) {
        if (!localStorage.getItem('signed-in-user-bool')) {
            context.redirect('#/auth');
            return;
        }

        templates.get('panel')
          .then(function (content) {
              context.$element().html(content);
          });
    }

    function show(id, selector) {
        templates.get('project')
          .then(function (content) {
              var $content = $(content);

              jsonRequester.get(serverUrl + 'api/Projects/' + id)
                .then(function (project) {
                    $content.find('#project-name').text(project.Name);
                    $content.find('#project-date').text(project.CreatedOn);
                    $content.find('#project-content').html(project.Content);
                    $content.find('#project-author').html('<i class="glyphicon glyphicon-user">' + project.Author.UserName + '</i>');

                    if (project.VideoUrl) {
                        var location = project.VideoUrl.substr(project.VideoUrl.indexOf('watch?v=') + 'watch?v='.length);
                        $content.find('#project-video').css({ padding: '3%' }).html('<iframe width="420" height="345" src="http://www.youtube.com/embed/' +
                            location
                            + '?autoplay=0" frameborder="0" allowfullscreen></iframe>');

                        console.log(location);
                    }

                    $(selector).html($content);
                });
          });
    }

    return {
        all: all,
        show, show
    };
}();