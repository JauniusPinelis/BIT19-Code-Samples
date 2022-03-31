using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoApplication.Data;
using TodoSolution.Domain.Interfaces;
using TodoSolution.Infrastructure.Repositories;

namespace TodoSolution.Infrastructure
{
    public static class DependencyInjection
    {
        public static void RegisterDatabase(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<DataContext>(d => d.UseSqlServer(connectionString));
            serviceCollection.AddTransient<ITodoRepository, MongoTodoRepository>();
        }
    }
}
