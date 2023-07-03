using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS.Repository.Extension
{
    public static class FilterExtension
    {
        public static IQueryable<TEntity> Filter<TEntity>(this IQueryable<TEntity> query, string filter, params string[] propertyNames) where TEntity : class
        {
            if (string.IsNullOrEmpty(filter) || propertyNames.Length == 0) return query;
            var filterList = filter.ToLower().Split(",").ToList();
            var filteredQuery = query;
            foreach (var propertyName in propertyNames)
            {
                filteredQuery = filteredQuery.Where(p => filterList.Count == 0 || filterList.Contains(p.GetType().GetProperty(propertyName).GetValue(p, null).ToString().ToLower()));
            }
            return filteredQuery;
        }

    }
}
