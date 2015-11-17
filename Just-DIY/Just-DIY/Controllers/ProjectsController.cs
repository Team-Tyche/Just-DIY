namespace Just_DIY.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Just_DIY.Data.Data;
    using Just_DIY.Models;
    using Just_DIY.Models.Projects;

    public class ProjectsController : ApiController
    {
        private IJustDIYData data;

        public ProjectsController(IJustDIYData data)
        {
            this.data = data;
        }

        // GET api/Projects/id
        public IHttpActionResult Get()
        {
            return this.Ok(this.data.Projects.All().AsQueryable().ProjectTo<ProjectViewModel>());
        }

        // GET api/Projects/id
        public IHttpActionResult Get(int id)
        {
            return this.Ok(Mapper.Map<ProjectViewModel>(this.data.Projects.Find(id)));
        }

        public IHttpActionResult Post([FromBody]CreateBindingModel model)
        {
            var project = new Project
            {
                Name = model.Name,
                CreatedOn = model.CreatedOn,
                Content = model.Content,
                VideoUrl = model.VideoUrl,
                AuthorId = model.AuthorId,
                Category = (Category)model.CategoryId
            };

            this.data.Projects.Add(project);
            this.data.SaveChanges();

            return this.Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            this.data.Projects.Delete(id);
            this.data.SaveChanges();
            return this.Ok();
        }
    }
}
