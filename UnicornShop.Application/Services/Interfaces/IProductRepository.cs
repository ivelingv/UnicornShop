using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnicornShop.Application.Models;

namespace UnicornShop.Application.Services.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetByCategoryAsync(long? categoryId);
        Task<bool> IsProductUniqueAsync(string name);
    }
}
