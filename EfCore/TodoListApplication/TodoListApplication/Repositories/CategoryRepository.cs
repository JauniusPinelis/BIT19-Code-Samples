using TodoListApplication.Data;
using TodoListApplication.Models;

namespace TodoListApplication.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>
    {

        public CategoryRepository(DataContext context) : base(context)
        {

        }
    }
}
