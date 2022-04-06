using board_service.Models;
using Microsoft.EntityFrameworkCore;

namespace board_service.DBContexts;

public class MyDbContext : DbContext
{
    public DbSet<Board> Boards { get; set; }
    
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Map entity to table
        modelBuilder.Entity<Board>().ToTable("board");
        
        // Configure primary key
        modelBuilder.Entity<Board>().HasKey(b => b.Id).HasName("pk_board");
        
        
        // Configure indexes
        modelBuilder.Entity<Board>().HasIndex(b => b.Id).IsUnique().HasDatabaseName("idx_board_id");
        
        // Configure columns
        modelBuilder.Entity<Board>().Property(b => b.Id).HasColumnName("board_id");
    }
}