namespace Just_DIY.Data.Data
{
    using Just_DIY.Data.Repositories;
    using Just_DIY.Models;

    public interface IJustDIYData
    {
        IRepository<User> Users { get; }

        IRepository<Project> Projects { get; }

        IRepository<Vote> Votes { get; }

        IRepository<Favourite> Favourites { get; }

        int SaveChanges();
    }
}
