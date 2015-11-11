var controllers = controllers || {};
(function(scope) {

  function all(context) {
    var myCookie;
    data.myCookies.get()
      .then(function(resMyCookie) {
        myCookie = resMyCookie;
        // myCookie.timePassed =  
        return templates.get('my-project');
      }).then(function(template) {
        context.$element().html(template(myCookie));
        $('.btn.btn-success').on('click', function() {
          var $this = $(this),
            projectId = $this.parents('.project-box').attr('data-id');
          data.projects.like(projectId)
            .then(function(project) {
              $this.parents('.project-box').find('.likes').html(project.likes);
              toastr.clear();
              toastr.success('Cookie liked!');
            });
        });
        $('.btn.btn-danger').on('click', function() {
          var $this = $(this),
            projectId = $this.parents('.project-box').attr('data-id');
          data.projects.dislike(projectId)
            .then(function(project) {
              toastr.clear();
              toastr.error('Cookie disliked!');
              $this.parents('.project-box').find('.dislikes').html(project.dislikes);
            });
        });
      });
  }

  scope.myCookie = {
    all: all,
  };
}(controllers));
