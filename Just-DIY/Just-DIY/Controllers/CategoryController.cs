using Just_DIY.Data.Data;
using Just_DIY.Models.Projects;
using System.Linq;
using System.Web.Http;

using AutoMapper.QueryableExtensions;

namespace Just_DIY.Controllers
{
    public class CategoryController : ApiController
    {
        private IJustDIYData data;

        public CategoryController(IJustDIYData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get(int id)
        {
            if (id == 0)
            {
                return this.Ok(this.data.Projects.All().OrderByDescending(x => x.CreatedOn).AsQueryable().ProjectTo<ProjectViewModel>());
            }

            var projects = this.data.Projects.FindWhere(x => (int)x.Category == id).OrderByDescending(x => x.CreatedOn).ToList();

            if(projects.Count == 0)
            {
                return this.NotFound();
            } else
            {
                return this.Ok(projects.AsQueryable().ProjectTo<ProjectViewModel>());
            }
        }
    }
}