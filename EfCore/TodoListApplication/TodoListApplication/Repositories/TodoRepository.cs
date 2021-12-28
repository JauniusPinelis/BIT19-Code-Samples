using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TodoListApplication.Data;
using TodoListApplication.Models;

namespace TodoListApplication.Repositories
{
    public class TodoRepository : RepositoryBase<Todo>
    {

        public TodoRepository(DataContext context) : base(context)
        {

        }

        public new List<Todo> GetAll()
        {
            return _context.Todos.Include(i => i.Category).Include(i => i.TodoTags).ThenInclude(tt => tt.Tag).ToList();
        }

        public void Create(Todo todo, List<int> tagsIds)
        {
            base.Create(todo);

            foreach (var tagId in tagsIds)
            {
                _context.TodoTags.Add(new TodoTag()
                {
                    TagId = tagId,
                    TodoId = todo.Id
                });
            }

            _context.SaveChanges();
        }
    }
}
