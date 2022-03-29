using Microsoft.Extensions.DependencyInjection;
using TodoSolution.Domain.Services;

namespace TodoSolution.Domain
{
    public static class DependencyInjection
    {
        public static void RegisterDomain(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<TodoService>();
        }
    }
}
