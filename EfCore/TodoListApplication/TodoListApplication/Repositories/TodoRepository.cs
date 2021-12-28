using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TodoListApplication.Data;
using TodoListApplication.Models;

namespace TodoListApplication.Repositories
{
    public class TodoRepository
    {
        private DataContext _context;

        public TodoRepository(DataContext context)
        {
            _context = context;
        }

        public List<Todo> GetAll()
        {
            //Filter out isDeleted
            return _context.Todos.Include(t => t.Category).ToList();
        }

        public Todo GetById(int id)
        {
            return _context.Todos.FirstOrDefault(t => t.Id == id);
        }

        public void Add(Todo todo, List<int> tagsIds)
        {
            todo.Created = System.DateTime.Now;
            todo.LastModified = System.DateTime.Now;

            _context.Add(todo);

            _context.SaveChanges();

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

        public void Update(Todo todo)
        {
            todo.LastModified = System.DateTime.Now;

            _context.Update(todo);

            _context.SaveChanges();
        }

        public void Delete(int todoId)
        {
            var todo = GetById(todoId);
            // impletent soft delete

            _context.Remove(todo);

            _context.SaveChanges();
        }
    }
}
