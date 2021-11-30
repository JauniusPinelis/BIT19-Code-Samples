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

        public void Update(string title, Book updateInfo)
        {
            var book = _books.SingleOrDefault(b => b.Title == title);

            if (book == null)
            {
                throw new ArgumentException("Book was not found");
            }

            book.Title = updateInfo.Title;
            book.Description = updateInfo.Description;
            book.Amount = updateInfo.Amount;
        }

        public void Remove(string title)
        {
            _books = _books.Where(b => b.Title != title).ToList();
        }
    }
}
