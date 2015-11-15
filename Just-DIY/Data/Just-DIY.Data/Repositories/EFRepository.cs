namespace Just_DIY.Data.Repositories
{
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using IdentityHelpers;

    public class EFRepository<T> : IRepository<T> where T : class
    {
        private IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim> context;
        private IDbSet<T> set;

        public EFRepository(IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim> context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }
        
        public IQueryable<T> All()
        {
            return this.set;
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public T Delete(object id)
        {
            var entity = this.Find(id);
            return this.Delete(entity);
        }

        public T Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public T Find(object id)
        {
            return this.set.Find(id);
        }
        
        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if(entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}
