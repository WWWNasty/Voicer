using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models.Entities;

namespace BusinessLogicLayer.Abstraction.Repositories.Base
{
    public interface IBaseRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        Task<TEntity> GetAsync(TId id);
        Task<ICollection<TEntity>> GetAllAsync();
        
        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);
        
        void Delete(TEntity entity);

        Task<T> GetDto<T>(TId id);
    }
}