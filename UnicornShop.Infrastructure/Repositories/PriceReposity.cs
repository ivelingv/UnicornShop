using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnicornShop.Application.Models;
using UnicornShop.Application.Services.Interfaces;
using UnicornShop.Infrastructure.Database.Configuration;

namespace UnicornShop.Infrastructure.Repositories
{
    public class PriceReposity : IPriceReposity
    {
        private readonly DatabaseContext _context;

        public PriceReposity(DatabaseContext context)
        {
            _context = context;
        }


        public Task DeleteAsync(Price entity)
        {
            _context.Prices.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<Price> GetAsync(long? id)
        {
            return await _context.Prices.AsQueryable()
                .Where(e => e.Id == id)
                .SingleAsync();
        }

        public async Task<IEnumerable<Price>> GetAsync()
        {
            return await _context.Prices.AsQueryable()
               .ToListAsync();
        }

        public async Task<Price> GetByProductAsync(long? productId)
        {
            return await _context.Prices.AsQueryable()
                .Where(e => e.Product.Id == productId)
                .FirstOrDefaultAsync();
        }

        public async Task<long?> SaveAsync(Price entity)
        {
            await _context.Prices.AddAsync(entity);
            return entity.Id;
        }

        public Task UpdateAsync(Price entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
