using BaseCore.DataAccess.Abstract;
using BaseCore.Utilities.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BaseCore.DataAccess.Concrete
{
    public class EfCoreGenericRepository<T, TContext> : IRepository<T>
          where T : class, new()
          where TContext : DbContext
    {
        private readonly TContext _context;

        public EfCoreGenericRepository(TContext context)
        {
            _context = context;
        }

        public IResult Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return new SuccessDataResult<T>(entity, "Messages.Add");
        }

        public IResult Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            _context.SaveChanges();

            return new SuccessDataResult<T>(entity, "Messages.Update");
        }

        public IResult Delete(T entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();

            return new SuccessDataResult<T>(entity, "Messages.Delete");
        }

        public async Task<IResult> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return new SuccessDataResult<T>(entity, "Messages.Add");
        }

        public async Task<IResult> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return new SuccessDataResult<T>(entity, "Messages.Update");
        }

        public async Task<IResult> DeleteAsync(T entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return new SuccessDataResult<T>(entity, "Messages.Delete");
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> expression = null)
        {
            return expression == null
                ? _context.Set<T>()
                : _context.Set<T>().Where(expression);
        }

        public T Get(Expression<Func<T, bool>> expression = null)
        {
            return expression == null
                ? _context.Set<T>().FirstOrDefault()
                : _context.Set<T>().FirstOrDefault(expression);
        }

        public T GetWithIncludes(Expression<Func<T, bool>> filter, List<Expression<Func<T, object>>> includes)
        {
            IQueryable<T> dbQuery = _context.Set<T>();
            if (includes != null)
            {
                dbQuery = includes.Aggregate(dbQuery,
                    (current, include) => current.Include(include));
            }
            var model = filter == null ? dbQuery.FirstOrDefault() : dbQuery.Where(filter).FirstOrDefault();
            return model;
        }

        public IEnumerable<T> GetListWithIncludes(List<Expression<Func<T, object>>> includes, Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> dbQuery = _context.Set<T>();

            if (includes != null)
            {
                dbQuery = includes.Aggregate(dbQuery,
                    (current, include) => current.Include(include));
            }

            var list = filter == null ? dbQuery.ToList() : dbQuery.Where(filter).ToList();
            return list;
        }
    }
}
