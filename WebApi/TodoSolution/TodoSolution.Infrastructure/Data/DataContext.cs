using Microsoft.EntityFrameworkCore;
using TodoSolution.Domain.Models;

namespace TodoApplication.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
