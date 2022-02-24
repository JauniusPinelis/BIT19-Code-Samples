using Microsoft.EntityFrameworkCore;
using ShopWithDiscountProject.Data;
using ShopWithDiscountProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopWithDiscountProject.Repositories
{
    public class ShopItemRepository : IShopItemRepository
    {
        private DataContext _context;

        public ShopItemRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ShopItem>> GetAllAsync()
        {
            return await _context.ShopItems.ToListAsync();
        }

        public async Task<ShopItem> GetShopByNameAsync(string name)
        {
            return await _context.ShopItems.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<ShopItem> CreateAsync(ShopItem shopItem)
        {
            _context.ShopItems.Add(shopItem);
            await _context.SaveChangesAsync();

            return shopItem;
        }
    }
}
