namespace Just_DIY.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class
    {
        ICollection<T> All();

        T Find(object id);

        ICollection<T> FindWhere(Expression<Func<T, bool>> condition);

        void Add(T entity);

        void Update(T entity);

        T Delete(T entity);

        T Delete(object id);

        int SaveChanges();
    }
}
