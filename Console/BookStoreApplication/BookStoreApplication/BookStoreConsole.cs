using BookStoreApplication.Model;

namespace BookStoreApplication
{
    public class BookStoreConsole
    {
        private BookStore _bookStore { get; set; }

        public BookStoreConsole()
        {
            _bookStore = new BookStore();
        }

        public void ExecuteAdd()
        {
            try
            {

                Console.WriteLine("Please enter title");
                var title = Console.ReadLine();

                Console.WriteLine("Please enter description");
                var description = Console.ReadLine();

                Console.WriteLine("Please enter number");
                var number = Convert.ToInt32(Console.ReadLine());

                _bookStore.Add(title, description, number);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something bad has happened, please try again");
                //continue
            }
        }

        public void ExecuteUpdate()
        {
            Console.WriteLine("Please enter the title of the book you want to update");

            var title = Console.ReadLine();

            Console.WriteLine("please enter the new title");
            var newTitle = Console.ReadLine();

            Console.WriteLine("please enter the new description");
            var description = Console.ReadLine();

            Console.WriteLine("please enter the new amount");
            var amount = Convert.ToInt32(Console.ReadLine());

            var updateInfo = new Book()
            {
                Amount = amount,
                Description = description,
                Title = newTitle
            };

            _bookStore.Update(title, updateInfo);
        }

        public void ExecuteList()
        {
            var books = _bookStore.GetAll();

            books.ForEach(book =>
                Console.WriteLine($"Name: {book.Title}, Description: {book.Description}, amount: {book.Amount}")
            );
        }

        public void ExecuteRemove()
        {
            Console.WriteLine("Please enter the title of the book you want to remove");
            var title = Console.ReadLine();

            _bookStore.Remove(title);
        }
    }
}
