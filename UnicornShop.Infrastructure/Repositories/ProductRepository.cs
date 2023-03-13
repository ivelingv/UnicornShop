using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicornShop.Application.Models;
using UnicornShop.Application.Services.Interfaces;
using UnicornShop.Infrastructure.Database.Configuration;

namespace UnicornShop.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;

        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(Product entity)
        {
            _context.Products.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<Product> GetAsync(long? id)
        {
            return await _context.Products.AsQueryable()
                .Where(e => e.Id == id)
                .SingleAsync();
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _context.Products.AsQueryable()
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(long? categoryId)
        {
            return await _context.Products.AsQueryable()
                .Where(e => e.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<long?> SaveAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);
            return entity.Id;
        }

        public Task UpdateAsync(Product entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return Task.CompletedTask;
        }
    }
}
