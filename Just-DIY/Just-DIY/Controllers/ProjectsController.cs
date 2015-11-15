using Just_DIY.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Just_DIY.Controllers
{
    public class ProjectsController : ApiController
    {
        private IJustDIYData data;

        public ProjectsController(IJustDIYData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get(int id)
        {
            return this.Ok(this.data.Projects.Find(id));
        }
    }
}
