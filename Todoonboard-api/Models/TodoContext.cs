using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Todoonboard_api.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;
        
        public DbSet<Board> Boards { get; set; } = null!;
        public DbSet<Users> Users { get; set; } = null!;


        
    }
}