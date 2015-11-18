var panelController = function () {

    function all(context) {
        templates.get('panel')
          .then(function (content) {
              context.$element().html(content);
          });
    }

    function show(id) {
        templates.get('project')
          .then(function (content) {
              var $content = $(content);

              jsonRequester.get('http://localhost:29004/api/Projects/' + id)
                .then(function (project) {
                    $content.find('#project-name').text(project.Name);
                    $content.find('#project-date').text(project.CreatedOn);
                    $content.find('#project-content').html(project.Content);

                    if (project.VideoUrl) {
                        var location = project.VideoUrl.substr(project.VideoUrl.indexOf('watch?v=') + 'watch?v='.length);
                        $content.find('#project-video').css({padding: '3%'}).html('<iframe width="420" height="345" src="http://www.youtube.com/embed/' +
                            location
                            + '?autoplay=0" frameborder="0" allowfullscreen></iframe>');

                        console.log(location);
                    }

                    $('#projects-container').html($content);
                });
          });
    }

    return {
        all: all,
        show, show
    };
}();