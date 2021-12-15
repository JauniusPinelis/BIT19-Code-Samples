using Microsoft.EntityFrameworkCore;
using TodoListApplication.Models;

namespace TodoListApplication.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
    }
}
