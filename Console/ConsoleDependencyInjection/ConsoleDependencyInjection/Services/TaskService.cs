namespace ConsoleDependencyInjection.Services
{
    public class TaskService
    {
        private DataService _dataService;

        public TaskService(DataService dataService)
        {
            _dataService = dataService;
        }

        public void Execute()
        {
            _dataService.ExecuteData();
            Console.WriteLine("Executing Task Service");
        }
    }
}
