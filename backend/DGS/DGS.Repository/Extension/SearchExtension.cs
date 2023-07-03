using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.Repository.Extension
{
    public static class SearchExtension
    {
        public static IQueryable<TEntity> Search<TEntity>(this IQueryable<TEntity> query, string searchTerm, params string[] propertyNames) where TEntity : class
        {
            var type = typeof(TEntity);
            var properties = type.GetProperties();
            var searchQuery = query;
            foreach (var propertyName in propertyNames)
            {
                searchQuery = searchQuery.AsEnumerable().Where(e => e.GetType().GetProperty(propertyName).GetValue(e).ToString().ToLower().Contains(searchTerm)).AsQueryable();
            }
            return searchQuery;
        }
    }
}
