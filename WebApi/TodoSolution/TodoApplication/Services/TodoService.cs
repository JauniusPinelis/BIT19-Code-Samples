using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TodoApplication.Data;
using TodoApplication.Dtos;
using TodoApplication.Models;

namespace TodoApplication.Services
{
    public class TodoService
    {
        private readonly DataContext _dataContext;

        public TodoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Todo> GetByIdAsync(int id)
        {
            var todo = await _dataContext.Todos.FindAsync(id);
            if (todo == null)
            {
                throw new ArgumentException("Todo not found");
            }

            return todo;
        }

        public async Task RemoveAsync(int id)
        {
            var todo = await GetByIdAsync(id);

            _dataContext.Todos.Remove(todo);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<int> CreateAsync(CreateTodo createTodo)
        {
            var doesNameExist = _dataContext.Todos.Select(x => x.Name).Contains(createTodo.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("The name already exists");
            }

            var model = new Todo()
            {
                Name = createTodo.Name
            };

            _dataContext.Todos.Add(model);
            await _dataContext.SaveChangesAsync();

            return model.Id;
        }

        public async Task UpdateAsync(int id, UpdateTodo updateTodo)
        {

            var todo = await GetByIdAsync(id);

            var doesNameExist = await _dataContext.Todos.AnyAsync(x => x.Name == updateTodo.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("The name already exists");
            }

            todo.Name = updateTodo.Name;

            await _dataContext.SaveChangesAsync();
        }
    }
}
