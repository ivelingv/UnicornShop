using System.Collections.Generic;
using System.Threading.Tasks;
using UnicornShop.Application.Models;

namespace UnicornShop.Application.Services.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : IDatabaseModel
    {
        Task<TEntity> GetAsync(long? id);

        Task<IEnumerable<TEntity>> GetAsync();

        Task<long?> SaveAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}
