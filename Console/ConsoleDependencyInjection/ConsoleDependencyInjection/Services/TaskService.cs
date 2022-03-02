using ConsoleDependencyInjection.Interfaces;
using ConsoleDependencyInjection.Models;

namespace ConsoleDependencyInjection.Services
{
    public class TaskService
    {
        private DataService _dataService;
        private FileService _fileService;
        private IOutputService _outputService;

        public TaskService(DataService dataService, FileService fileService, IOutputService outputService)
        {
            _dataService = dataService;
            _fileService = fileService;
            _outputService = outputService;
        }

        public async Task ExecuteAsync()
        {
            List<Todo> todos = await _fileService.ReadFileAsync();
            todos.ForEach(todo => Console.WriteLine($"todo: id: {todo.Id}, name: {todo.Name}"));

            _dataService.ExecuteData();
            _outputService.Print("Executing Task Service");
        }
    }
}
