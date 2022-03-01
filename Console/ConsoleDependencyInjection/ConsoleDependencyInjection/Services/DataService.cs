using ConsoleDependencyInjection.Interfaces;

namespace ConsoleDependencyInjection.Services
{
    public class DataService
    {
        private IOutputService _outputService;

        public DataService(IOutputService outputService)
        {
            _outputService = outputService;
        }

        public void ExecuteData()
        {
            _outputService.Print("Executing Data Service");
        }
    }
}
