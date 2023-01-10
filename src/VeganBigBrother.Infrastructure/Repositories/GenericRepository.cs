using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VeganBigBrother.Core.Entities;
using VeganBigBrother.Core.Exceptions;
using VeganBigBrother.Core.Interfaces;
using VeganBigBrother.Infrastructure.Database;

namespace VeganBigBrother.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DatabaseContext context;

        protected DbSet<TEntity> dbSet;

        public GenericRepository(DatabaseContext context)
        {
            this.context = context;

            dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query.AsNoTracking());
            }
            else
            {
                return query.AsNoTracking();
            }
        }

        public TEntity GetById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return dbSet.AsNoTracking().SingleOrDefault(x => x.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public virtual async Task<int> Create(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            return await context.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = GetById(id);

            if (entity == null)
            {
                throw new EntityDoesNotExistException(typeof(TEntity), id);
            }

            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
