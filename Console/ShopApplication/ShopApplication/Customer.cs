namespace ShopApplication
{
    public class Customer
    {
        private int _balance = 10;

        public int GetBalance()
        {
            return _balance;
        }

        public void Charge(int amount)
        {
            _balance -= amount;
        }
    }
}
