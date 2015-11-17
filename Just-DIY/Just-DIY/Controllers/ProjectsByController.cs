namespace Just_DIY.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data.Data;
    using Models.Projects;
    
    public class ProjectsByController : ApiController
    {
        private IJustDIYData data;

        public ProjectsByController(IJustDIYData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get(int id)
        {
            return this.Ok(this.data.Projects.FindWhere(x => x.AuthorId == id).AsQueryable().ProjectTo<ProjectsByViewModel>());
        }

        public IHttpActionResult Get([FromUri]ProjectsByModel model)
        {
            return this.Ok(this.data.Projects.FindWhere(x => x.Author.UserName == model.AuthorUsername).AsQueryable().ProjectTo<ProjectsByViewModel>());
        }
    }
}