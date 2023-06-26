using DGS.BusinessObjects;
using DGS.BusinessObjects.Common;
using DGS.DataAccess.interfaces;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DGS.DataAccess.impls
{
    public class EntityDAO<T, K> : IDAO<T, K> where T : BaseEntity<K>
    {
        private readonly ApplicationDbContext _context;

        public EntityDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<T>> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> items = _context.Set<T>();
                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        items = items.Include(includeProperty);
                    }
                }
                return await items.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }

        public async Task<List<T>> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {

            try
            {
                IQueryable<T> items = _context.Set<T>();
                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        items = items.Include(includeProperty);
                    }
                }
                return await items.Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }

        public async Task<T> FindById(K id, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> items = _context.Set<T>();
                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        items = items.Include(includeProperty);
                    }
                }
                return await items.FirstOrDefaultAsync(x => x.Id.Equals(id));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<T> FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> items = _context.Set<T>();
                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        items = items.Include(includeProperty);
                    }
                }
                return await items.SingleOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task Remove(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task Remove(K id)
        {
            try
            {
                var entity = FindById(id).Result;
                await Remove(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task RemoveMultiple(List<T> entities)
        {
            try
            {
                _context.Set<T>().RemoveRange(entities);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task Update(T entity, params string[] propertiesToExclude)
        {
            try
            {
                _context.Set<T>().Attach(entity);
                var entry = _context.Entry(entity);
                entry.State = EntityState.Modified;
                foreach (var property in propertiesToExclude)
                {
                    entry.Property(property).IsModified = false;
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
