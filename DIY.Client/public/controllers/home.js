var controllers = controllers || {};
(function(scope) {

  function all(context) {
    var sortby = context.params.sortby || 'date',
      category = context.params.category || null;
    var projects;

    data.projects.get()
      .then(function(resProjects) {
        projects = resProjects;
        if (category) {
          projects = projects.filter(function(project) {
            return project.category.toLowerCase() === category.toLowerCase();
          });
        }

        projects.sort(function(c1, c2) {
          if (sortby === 'date') {
            return (new Date(c2.shareDate)) - (new Date(c1.shareDate));
          }
          return c2.likes - c1.likes;
        });
        projects = projects.map(function(project) {
          project.timePast = moment(project.shareDate).fromNow();
          project.shareDate = moment(project.shareDate).format('Do MMM YYYY, HH:mm');
          return project;
        });

        return templates.get('projects');
      })
      .then(function(template) {
        context.$element().html(template(projects));

        $('.btn-like-dislike').on('click', function() {
          var $this = $(this),
            projectId = $this.parents('.project-box').attr('data-id'),
            type = $this.attr('data-type'),
            promise;
          if (type === 'like') {
            promise = data.projects.like(projectId);
          } else {
            promise = data.projects.dislike(projectId);
          }
          promise.then(function(project) {
            $this.parents('.project-box').find(`.${type}s`).html(project[`${type}s`]);
            toastr.clear();
            toastr.success(`Project ${type}d!`);
          });
        });

        $('.btn-share').on('click', function() {
          var $this = $(this),
            $projectBox = $this.parents('.project-box');
          var project = {
            text: $projectBox.find('.text').html().trim(),
            category: $projectBox.find('.category').html().trim(),
            img: $projectBox.find('img').attr('src')
          };
          data.projects.add(project)
            .then(function(project) {
              toastr.success(`Project "${project.text}" reshared!`);
              context.redirect('#/');
            });
        });

        $('.tb-filter').on('input', function() {
          var pattern = $(this).val().toLowerCase(),
            selector = '.' + $(this).attr('data-type');
          $('.project-box')
            .each(function(index, projectBox) {
              var $projectBox = $(projectBox),
                value = $projectBox.find(selector).html().trim().toLowerCase();
              if (value.indexOf(pattern) >= 0) {
                $projectBox.removeClass('hide');
              } else {
                $projectBox.addClass('hide');
              }
            });
        });
      });
  }

  function add(context) {
    templates.get('project-add')
      .then(function(template) {
        context.$element().html(template());
        return data.categories.get();
      })
      .then(function(categories) {

        $('#tb-project-category').autocomplete({
          source: categories
        });

        $('#tb-project-img').on('input', function() {
          var url = $(this).val();
          $('#project-img-preview').attr('src', url);
        });

        $('#btn-add-project').on('click', function() {
          var project = {
            text: $('#tb-project-text').val(),
            category: $('#tb-project-category').val(),
            img: $('#tb-project-img').val()
          };
          data.projects.add(project)
            .then(function(project) {
              toastr.success(`Project "${project.text}" addded!`);
              context.redirect('#/home');
            });
        });
      });
  }

  scope.home = {
    all: all,
    add: add
  };
}(controllers));
