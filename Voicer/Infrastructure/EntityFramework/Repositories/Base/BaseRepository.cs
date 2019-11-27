using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Repositories.Base;
using DataAccessLayer.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Repositories.Base
{
    public abstract class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId> where TEntity : Entity<TId>
    {
        protected readonly VotingDbContext _context;

        protected BaseRepository(VotingDbContext context)
        {
            _context = context;
        }
        public virtual async Task<TEntity> GetAsync(TId id)
        {
            var result = await GetDbSet().FindAsync(id);
             
            return result;
        }

        public virtual async Task<ICollection<TEntity>> GetAllAsync()
        {
            List<TEntity> result = await GetDbSet().ToListAsync();
           
            return result;
        }

        public virtual TEntity Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);

            return entity;
        }

        public void Delete(TEntity entity)
        {
            GetDbSet().Remove(entity);
        }

        protected DbSet<TEntity> GetDbSet()
        {
            return _context.Set<TEntity>();
        }
    }
}