using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Repositories.Base;
using DataAccessLayer.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Infrastructure.EntityFramework.Repositories.Base
{
    public abstract class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        protected readonly VotingDbContext _context;
        protected readonly IMapper _mapper;

        protected BaseRepository(VotingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        protected virtual DbSet<TEntity> GetDbSet()
        {
            return _context.Set<TEntity>();
        }

        public Task<T> GetDto<T>(TId id)
        {
            return GetDbSet().Where(entity => entity.Id.Equals(id)).ProjectTo<T>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }
    }
}