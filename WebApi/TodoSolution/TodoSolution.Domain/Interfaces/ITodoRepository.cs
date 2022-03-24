using TodoSolution.Domain.Models;

namespace TodoSolution.Domain.Interfaces
{
    public interface ITodoRepository
    {
        Task<Todo> GetByIdAsync(int id);
        Task<List<Todo>> GetAllAsync();

        Task<int> CreateAsync(Todo todo);

        Task RemoveAsync(Todo todo);

        Task<bool> DoesExist(string name);
    }
}
