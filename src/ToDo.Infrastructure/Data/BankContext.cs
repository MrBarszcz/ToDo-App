using ToDo.Core.Entities;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ToDo.Infrastructure.Data;

public class BankContext : DbContext {
    public BankContext(DbContextOptions<BankContext> options) : base(options) {
    }

    public DbSet<ToDoItemEntity> ToDoItem { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
}