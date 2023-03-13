using System.Threading.Tasks;
using UnicornShop.Application.Models;

namespace UnicornShop.Application.Services.Interfaces
{
    public interface IPriceReposity : IRepository<Price>
    {
        Task<Price> GetByProductAsync(long? productId);
    }

}
