using TestingExternalSystem.Models;

namespace TestingExternalSystem.Clients
{
    public class ExternalSystemClient : IExternalSystemClient
    {
        public async Task<List<Todo>> GetTodosAsync()
        {
            // Adapter pattern
            HttpClient client = new HttpClient();

            HttpResponseMessage httpResponseMessage = await client.GetAsync("https://jsonplaceholder.typicode.com/todos");

            var todos = await httpResponseMessage.Content.ReadAsAsync<List<Todo>>();

            return todos;
        }
    }
}
