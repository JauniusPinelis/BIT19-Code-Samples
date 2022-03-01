using ConsoleDependencyInjection.Interfaces;

namespace ConsoleDependencyInjection.Services
{
    public class ConsoleService : IOutputService
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
