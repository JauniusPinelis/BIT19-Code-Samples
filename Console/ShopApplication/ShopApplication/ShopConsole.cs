namespace ShopApplication
{
    public class ShopConsole
    {
        private Shop _shop = new Shop();

        public void ExecuteBuy()
        {
            Console.WriteLine("Please enter 'Name Amount' for example: IceCream 300");
            try
            {
                var input = Console.ReadLine();
                var words = input.Split(" ");
                var amountString = words.Last();
                var amount = int.Parse(amountString);

                var itemName = words.First();

                _shop.Buy(itemName, amount);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void ExecuteShowBalance()
        {
            var balance = _shop.GetCustomerBalance();
            Console.WriteLine($"Buyer's balance is {balance}");
        }

        public void ExecutePrintInfo()
        {
            var info = _shop.GetShopItemsInfo();
            Console.WriteLine(info);
        }
    }
}
