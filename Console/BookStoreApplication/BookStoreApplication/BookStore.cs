using BookStoreApplication.Model;

namespace BookStoreApplication
{
    public class BookStore
    {
        private List<Book> _books = new List<Book>();

        public void Add(string title, string description, int amount)
        {
            var bookExists = _books.Any(x => x.Title == title);

            if (bookExists)
            {
                throw new ArgumentException("Book already exists");
            }

            var book = new Book()
            {
                Amount = amount,
                Title = title,
                Description = description
            };

            _books.Add(book);
            // Add a book
        }

        public List<Book> GetAll()
        {
            return _books;
        }

        public void Remove(string title)
        {
            _books = _books.Where(b => b.Title != title).ToList();
        }
    }
}
