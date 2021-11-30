using SampleShop.Models;

namespace SampleShop
{
    public class Shop
    {
        public Buyer Buyer { get; set; }

        public List<ShopItem> ShopItems { get; set; }

        public Shop()
        {
            Buyer = new Buyer();

            ShopItems = new List<ShopItem>()
            {
                new ShopItem(){ Name = "Candy", Price = 1.34M}
            };
        }

        public void Buy(string itemName)
        {

        }
    }
}
