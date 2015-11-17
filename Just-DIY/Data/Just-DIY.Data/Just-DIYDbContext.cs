namespace Just_DIY.Data
{
    using System.Data.Entity;

    using Just_DIY.IdentityHelpers;
    using Just_DIY.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class Just_DIYDbContext : IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public Just_DIYDbContext()
            : base("DefaultConnection")
        {
        }

        public IDbSet<Favourite> Favourites { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        public IDbSet<Project> Projects { get; set; }

        public static Just_DIYDbContext Create()
        {
            return new Just_DIYDbContext();
        }
    }
}
