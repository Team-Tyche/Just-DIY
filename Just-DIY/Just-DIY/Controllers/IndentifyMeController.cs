namespace Just_DIY.Controllers
{
    using Microsoft.AspNet.Identity;
    using System.Web.Http;

    [Authorize]
    public class IdentifyMeController : ApiController
    {
        public int Get()
        {
            return int.Parse(User.Identity.GetUserId());
        }
    }
}