using TodoSolution.Domain.Dtos;
using TodoSolution.Domain.Interfaces;
using TodoSolution.Domain.Models;

namespace TodoSolution.Domain.Services
{
    public class TodoService
    {
        private readonly ITodoRepository _todoRepository;


        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }


        public async Task<Todo> GetByIdAsync(string id)
        {
            var todo = await _todoRepository.GetByIdAsync(id);
            if (todo == null)
            {
                throw new ArgumentException("Todo not found");
            }

            return todo;
        }

        public async Task RemoveAsync(string id)
        {
            var todo = await GetByIdAsync(id);

            await _todoRepository.RemoveAsync(todo);
        }

        public async Task<string> CreateAsync(CreateTodo createTodo)
        {
            var doesNameExist = await _todoRepository.DoesExist(createTodo.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("The name already exists");
            }

            var model = new Todo()
            {
                FullName = createTodo.Name
            };

            await _todoRepository.CreateAsync(model);


            return model.Id;
        }

        //public async Task UpdateAsync(int id, UpdateTodo updateTodo)
        //{

        //    var todo = await GetByIdAsync(id);

        //    var doesNameExist = await _dataContext.Todos.AnyAsync(x => x.Name == updateTodo.Name);
        //    if (doesNameExist)
        //    {
        //        throw new ArgumentException("The name already exists");
        //    }

        //    todo.Name = updateTodo.Name;

        //    await _dataContext.SaveChangesAsync();
        //}
    }
}
