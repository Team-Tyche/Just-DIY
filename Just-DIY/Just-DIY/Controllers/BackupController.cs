using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Just_DIY.Controllers
{
    using System.Reflection;
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

        public async Task<IHttpActionResult> Get(string id)
        {
            switch (id.ToLowerInvariant())
            {
                case "users":
                    await DropboxManager.SaveBackup(new List<User>(this.data.Users.All()));
                    break;
                case "votes":
                    await DropboxManager.SaveBackup(new List<Vote>(this.data.Votes.All()));
                    break;
                case "projects":
                    await DropboxManager.SaveBackup(new List<Project>(this.data.Projects.All()));
                    break;
                case "favourites":
                    await DropboxManager.SaveBackup(new List<Favourite>(this.data.Favourites.All()));
                    break;
                default:
                    return this.BadRequest();
            }

            return this.Ok("All "+ id + " were backed up.");
        }
    }
}