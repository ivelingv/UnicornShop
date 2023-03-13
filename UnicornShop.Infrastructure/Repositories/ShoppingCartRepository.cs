using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnicornShop.Application.Models;
using UnicornShop.Application.Services.Interfaces;
using UnicornShop.Infrastructure.Database.Configuration;

namespace UnicornShop.Infrastructure.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly DatabaseContext _context;

        public ShoppingCartRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task DeleteAsync(ShoppingCart entity)
        {
            _context.ShoppingCarts.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<ShoppingCart> GetAsync(long? id)
        {
            return await _context.ShoppingCarts.AsQueryable()
                .Where(e => e.Id == id)
                .SingleAsync();
        }

        public async Task<IEnumerable<ShoppingCart>> GetAsync()
        {
            return await _context.ShoppingCarts.AsQueryable()
                .ToListAsync();
        }

        public async Task<long?> SaveAsync(ShoppingCart entity)
        {
            await _context.ShoppingCarts.AddAsync(entity);
            return entity.Id;
        }

        public Task UpdateAsync(ShoppingCart entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return Task.CompletedTask;
        }
    }
}
