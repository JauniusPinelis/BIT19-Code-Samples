using Microsoft.Extensions.DependencyInjection;

namespace TodoSolution.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterDatabase(this ServiceCollection serviceCollection, string connectionString)
        {
            //serviceCollection.AddDbContext<DataContext>(d => d.UseSqlServer(connectionString));
        }
    }
}
