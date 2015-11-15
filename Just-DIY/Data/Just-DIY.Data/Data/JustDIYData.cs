namespace Just_DIY.Data.Data
{
    using System;
    using System.Collections.Generic;

    using Just_DIY.Data.Repositories;
    using Just_DIY.IdentityHelpers;
    using Just_DIY.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class JustDIYData : IJustDIYData
    {
        private IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim> context;
        private IDictionary<Type, object> repositories;

        public JustDIYData(IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim> context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Favourite> Favourites
        {
            get
            {
                return this.GetRepository<Favourite>();
            }
        }

        public IRepository<Project> Projects
        {
            get
            {
                return this.GetRepository<Project>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Vote> Votes
        {
            get
            {
                return this.GetRepository<Vote>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);

            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
