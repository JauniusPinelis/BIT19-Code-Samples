using TodoSolution.Domain.Interfaces;
using TodoSolution.Domain.Models;

namespace TodoSolution.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        public Task<int> CreateAsync(Todo todo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DoesExist(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Todo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Todo> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Todo todo)
        {
            throw new NotImplementedException();
        }
    }
}
