using ConsoleDependencyInjection.Interfaces;
using ConsoleDependencyInjection.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleDependencyInjection
{
    public static class DependencyInjection
    {
        // Extension methods
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<TaskService>();
            services.AddTransient<DataService>();
            services.AddTransient<IOutputService, FileService>();
            services.AddTransient<FileService>();
        }
    }
}