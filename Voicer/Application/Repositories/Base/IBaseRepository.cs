using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models.Entities;

namespace BusinessLogicLayer.Abstraction.Repositories.Base
{
    public interface IBaseRepository<TEntity, TId> where TEntity : Entity<TId>
    {
        Task<TEntity> GetAsync(TId id);
        Task<ICollection<TEntity>> GetAllAsync();
        
        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);
        
        void Delete(TEntity entity);

    }
}