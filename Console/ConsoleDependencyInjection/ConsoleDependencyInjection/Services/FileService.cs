using ConsoleDependencyInjection.Interfaces;

namespace ConsoleDependencyInjection.Services
{
    public class FileService : IOutputService
    {
        public void Print(string message)
        {
            File.AppendAllText("test.txt", message);
        }
    }
}
