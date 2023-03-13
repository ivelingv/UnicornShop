using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicornShop.Application.Services.DTO;

namespace UnicornShop.Application.Services.Interfaces.Services
{
    public interface IProductService
    {
        public Task<long?> CreateProductAsync(
            CreateProductDTO createProduct);

        public Task UpdateProductAsync(
            long? productId, 
            UpdateProductDTO updateProduct);
    }
}
