using System.Collections.Generic;
using System.Linq;
using TodoListApplication.Data;
using TodoListApplication.Models;

namespace TodoListApplication.Repositories
{
    public class TagRepository
    {
        private DataContext _context;

        public TagRepository(DataContext context)
        {
            _context = context;
        }

        public List<Tag> GetAll()
        {
            //Filter out isDeleted
            return _context.Tags.ToList();
        }
    }
}
