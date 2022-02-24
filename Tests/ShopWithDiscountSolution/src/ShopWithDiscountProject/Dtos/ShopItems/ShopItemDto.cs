using System;

namespace ShopWithDiscountProject.Dtos.ShopItems
{
    public class ShopItemDto : CreateShopItem
    {
        public int Id { get; set; }

        public DateTime CreatedUtc { get; set; }
    }
}
