using Microsoft.EntityFrameworkCore;
using todo_app.Models;

namespace todo_app.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<TodoItem> Todos => Set<TodoItem>();
    }
}
