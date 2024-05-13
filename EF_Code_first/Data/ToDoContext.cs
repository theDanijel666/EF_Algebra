using Microsoft.EntityFrameworkCore;
using EF_Code_first.Models;

namespace EF_Code_first.Data
{
    public class ToDoContext:DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

        public DbSet<ToDoModel> ToDoModel { get; set; }
    }
}
