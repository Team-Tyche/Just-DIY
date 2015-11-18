namespace Just_DIY.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper.QueryableExtensions;
    using Just_DIY.Data.Data;
    using Just_DIY.Models;
    using Just_DIY.Models.Favourites;
    using Microsoft.AspNet.Identity;
    using Models.Projects;

    public class FavouritesController : ApiController
    {
        private IJustDIYData data;

        public FavouritesController(IJustDIYData data)
        {
            this.data = data;
        }

        [Authorize]
        public IHttpActionResult Get()
        {
            var myId = int.Parse(User.Identity.GetUserId());

            var favourites = this.data.Favourites.All().Where(x => x.UserId == myId).Select(x => x.ProjectId).ToArray();
            return this.Ok(this.data.Projects.FindWhere(x => favourites.Any(y => y == x.Id)).AsQueryable().ProjectTo<ProjectViewModel>());
        }
        
        [Authorize]
        public IHttpActionResult Post(int id)
        {
            var myId = int.Parse(User.Identity.GetUserId());

            if (this.data.Favourites.All().Any(x => x.ProjectId == id && x.UserId == myId))
            {
                return this.BadRequest("You already voted for this project.");
            }
            
            this.data.Favourites.Add(new Favourite {ProjectId = id, UserId = myId });

            this.data.SaveChanges();

            return this.Ok();
        }

        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var myId = int.Parse(User.Identity.GetUserId());

            if (!this.data.Favourites.All().Any(x => x.ProjectId == id && x.UserId == myId))
            {
                return this.BadRequest("No such project!");
            }

            this.data.Favourites.Delete(this.data.Favourites.FindWhere(x => x.ProjectId == id && x.UserId == myId).First());

            this.data.SaveChanges();

            return this.Ok();
        }
    }
}