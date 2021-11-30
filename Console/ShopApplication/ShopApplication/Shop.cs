using ShopApplication.Models;

namespace ShopApplication
{
    public class Shop
    {
        private Customer _customer = new Customer();

        private List<ShopItem> _shopItems = new List<ShopItem>()
        {
            new ShopItem(){ Name = "Ice Cream", Price = 1, Quantity = 4},
            new ShopItem(){ Name = "Candy", Price = 2, Quantity = 4},
            new ShopItem(){ Name = "Apple Pie", Price = 3, Quantity = 4},
        };

        public void Buy(string name, int amount)
        {
            var item = _shopItems.FirstOrDefault(x => x.Name == name);
            if (item == null)
            {
                throw new ArgumentException("Item was not found");
            }

            var totalPrice = item.Price * amount;

            var balance = _customer.GetBalance();

            if (totalPrice <= balance)
            {
                _customer.Charge(totalPrice);

                item.Quantity -= amount;
            }
            else
            {
                throw new ArgumentException("Not enough money");
            }
        }

        public int GetCustomerBalance()
        {
            return _customer.GetBalance();
        }

        public string GetShopItemsInfo()
        {
            var info = "";
            foreach (var shopItem in _shopItems)
            {
                var shopItemInfo =
                    $"name: {shopItem.Name}, quantity: {shopItem.Quantity}, price: {shopItem.Price}\n";
                info = info + shopItemInfo;
            }

            return info;
        }
    }
}
