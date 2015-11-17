namespace Just_DIY.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper;
    using Just_DIY.Data.Data;
    using Just_DIY.Models;
    using Just_DIY.Models.Favourites;

    public class FavouritesController : ApiController
    {
        private IJustDIYData data;

        public FavouritesController(IJustDIYData data)
        {
            this.data = data;
        }

        public IHttpActionResult Post([FromBody]FavouriteBindingModel favourite)
        {
            if (this.data.Favourites.All().Any(x => x.ProjectId == favourite.ProjectId && x.UserId == favourite.UserId))
            {
                return this.BadRequest("You already voted for this project.");
            }

            var newFavourite = Mapper.Map<Favourite>(favourite);
            this.data.Favourites.Add(newFavourite);

            this.data.SaveChanges();

            return this.Ok();
        }
    }
}