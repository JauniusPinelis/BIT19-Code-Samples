using System;
using System.Linq;
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

        public Todo GetById(int id)
        {
            var todo = _dataContext.Todos.Find(id);
            if (todo == null)
            {
                throw new ArgumentException("Todo not found");
            }

            return todo;
        }

        public void Remove(int id)
        {
            var todo = GetById(id);

            _dataContext.Todos.Remove(todo);
            _dataContext.SaveChanges();
        }

        public int Create(CreateTodo createTodo)
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
            _dataContext.SaveChanges();

            return model.Id;
        }

        public void Update(int id, UpdateTodo updateTodo)
        {

            var todo = GetById(id);

            var doesNameExist = _dataContext.Todos.Select(x => x.Name).Contains(updateTodo.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("The name already exists");
            }

            todo.Name = updateTodo.Name;

            _dataContext.SaveChanges();
            throw new SystemException();
        }
    }
}
