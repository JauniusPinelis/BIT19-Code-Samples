using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoSolution.Domain;
using TodoSolution.Infrastructure;

namespace TodoSolution.Application
{
    public static class DependencyInjection
    {
        public static void ConfigureApplication(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            serviceCollection.RegisterDomain();
            serviceCollection.RegisterDatabase(connectionString);
        }
    }
}
