namespace Just_DIY.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data.Data;
    using Models.Projects;
    using Microsoft.AspNet.Identity;

    public class ProjectsByController : ApiController
    {
        private IJustDIYData data;

        public ProjectsByController(IJustDIYData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get(int id)
        {
            return this.Ok(this.data.Projects.FindWhere(x => x.AuthorId == id).OrderByDescending(x => x.CreatedOn).AsQueryable().ProjectTo<ProjectsByViewModel>());
        }

        [Authorize]
        public IHttpActionResult Get()
        {
            var currentUserId = int.Parse(User.Identity.GetUserId());

            return this.Ok(this.data.Projects.FindWhere(x => x.AuthorId == currentUserId).AsQueryable().ProjectTo<ProjectViewModel>());
        }
    }
}