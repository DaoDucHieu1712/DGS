﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DGS.DataAccess.interfaces
{
    public interface IDAO<T, K> where T : class
    {
        Task<T> FindById(K id, Expression<Func<T, object>>[] includes);

        Task<T> FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        Task<List<T>>  FindAll(params Expression<Func<T, object>>[] includes);

        Task<List<T>> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        Task Add(T entity);

        Task Update(T entity, params string[] propertiesToExclude);

        Task Update(T entity);

        Task Remove(T entity);

        Task Remove(K id);

        Task RemoveMultiple(List<T> entities);
    }
}
