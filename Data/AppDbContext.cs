

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ToDoApp.Models;

namespace ToDoApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; }
    }

    //public class TodoContext : DbContext
    //{
    //    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    //    {
    //    }

    //    public DbSet<TodoItem> TodoItems { get; set; } = default!;
    //}

}