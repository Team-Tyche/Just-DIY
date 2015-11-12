namespace Just_DIY.Models
{
    using Just_DIY.IdentityHelpers;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class User : IdentityUser<int, CustomUserLogin, CustomUserRole,CustomUserClaim>
    {
        private ICollection<Favourite> favourites;
        private ICollection<Vote> votes;

        public User()
        {
            this.favourites = new HashSet<Favourite>();
            this.votes = new HashSet<Vote>();
        }

       public int Id { get; set; }

        public ICollection<Favourite> Favourites
        {
            get { return this.favourites; }
            set { this.favourites = value; }
        }

        public ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

        public string AccountName { get; set; }


        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
