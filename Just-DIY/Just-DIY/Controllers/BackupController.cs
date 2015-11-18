using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Just_DIY.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using Clients;
    using Data.Data;
    using Models;

    public class BackupController : ApiController
    {
        private IJustDIYData data;

        public BackupController(IJustDIYData data)
        {
            this.data = data;
        }

        public async Task<IHttpActionResult> Get()
        {
            await DropboxManager.SaveBackup(new List<User>(this.data.Users.All()));

            return this.Ok("All backed up.");
        }
    }
}