using TestingExternalSystem.Models;

namespace TestingExternalSystem.Clients
{
    public interface IExternalSystemClient
    {
        Task<List<Todo>> GetTodosAsync();
    }
}