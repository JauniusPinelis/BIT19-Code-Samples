using ConsoleDependencyInjection.Interfaces;

namespace ConsoleDependencyInjection.Services
{
    public class TaskService
    {
        private DataService _dataService;
        private IOutputService _outputService;

        public TaskService(DataService dataService, IOutputService outputService)
        {
            _dataService = dataService;
            _outputService = outputService;
        }

        public void Execute()
        {
            _dataService.ExecuteData();
            _outputService.Print("Executing Task Service");
        }
    }
}
