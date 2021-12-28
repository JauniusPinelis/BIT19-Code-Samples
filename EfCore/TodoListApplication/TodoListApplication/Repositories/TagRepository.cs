using TodoListApplication.Data;
using TodoListApplication.Models;

namespace TodoListApplication.Repositories
{
    public class TagRepository : RepositoryBase<Tag>
    {

        public TagRepository(DataContext context) : base(context)
        {
        }


    }
}
