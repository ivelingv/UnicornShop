using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicornShop.Application.Models;
using UnicornShop.Application.Services.DTO;
using UnicornShop.Application.Services.Interfaces;
using UnicornShop.Application.Services.Interfaces.Services;

namespace UnicornShop.Application.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IPriceReposity _priceReposity;
        private readonly IProductRepository _productRepository;

        public ProductService(
            IMapper mapper,
            IPriceReposity priceReposity,
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _priceReposity = priceReposity;
            _productRepository = productRepository;
        }

        public async Task<long?> CreateProductAsync(
            CreateProductDTO createProduct)
        {
            var price = new Price(
                createProduct.PriceAmount,
                createProduct.PriceCurrency);

            await _priceReposity.SaveAsync(price);

            var product = new Product(
                createProduct.Name,
                createProduct.Description,
                createProduct.CategoryId,
                createProduct.Quanitity,
                price);

            var isUnique = await _productRepository.IsProductUniqueAsync(
                product.Name);

            if (!isUnique)
            {
                throw new InvalidOperationException(
                    "Product name is not unique");
            }

            var productId = await _productRepository.SaveAsync(
                product);

            return productId;
        }

        public Task UpdateProductAsync(
            long? productId, 
            UpdateProductDTO updateProduct)
        {
            throw new NotImplementedException();
        }
    }
}
