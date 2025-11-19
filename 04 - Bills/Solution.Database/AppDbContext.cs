using Microsoft.EntityFrameworkCore;
using Solution.Database.Entities;

namespace Solution.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<AccountEntity> Accounts { get; set; } = null!;
    public DbSet<ItemEntity> Items { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
