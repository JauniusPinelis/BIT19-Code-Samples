using ConsoleDependencyInjection.Interfaces;
using ConsoleDependencyInjection.Models;

namespace ConsoleDependencyInjection.Services
{
    public class FileService : IOutputService
    {
        public void Print(string message)
        {
            File.AppendAllText("test.txt", message);
        }

        public async Task<List<Todo>> ReadFileAsync()
        {
            string[] lines = await File.ReadAllLinesAsync("Data/Input.txt");

            List<Todo> todos = new List<Todo>();

            foreach (var item in lines)
            {
                string[] info = item.Split(" ");
                var id = int.Parse(info[0]);
                var name = info[1];

                todos.Add(new Todo
                {
                    Id = id,
                    Name = name,
                });
            }

            return todos;
        }
    }
}
