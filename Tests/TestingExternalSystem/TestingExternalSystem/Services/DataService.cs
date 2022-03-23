using TestingExternalSystem.Clients;

namespace TestingExternalSystem.Services
{
    public class DataService
    {
        private IExternalSystemClient _client;

        public DataService(IExternalSystemClient client)
        {
            _client = client;
        }

        public async Task<int> CalculateShortWordsFromApi()
        {
            var todos = await _client.GetTodosAsync();

            var numbers = 0;

            foreach (var todo in todos)
            {
                var words = todo.Title.Split(" ");
                foreach (var word in words)
                {
                    if (word.Length == 2)
                    {
                        numbers++;
                    }
                }
            }

            Console.WriteLine($"There are {numbers} words with length of 2 ");

            return numbers;
        }
    }
}
