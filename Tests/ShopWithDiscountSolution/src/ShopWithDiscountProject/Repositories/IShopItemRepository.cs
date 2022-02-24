using ShopWithDiscountProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopWithDiscountProject.Repositories
{
    public interface IShopItemRepository
    {
        Task<ShopItem> CreateAsync(ShopItem shopItem);
        Task<List<ShopItem>> GetAllAsync();
        Task<ShopItem> GetShopByNameAsync(string name);
    }
}