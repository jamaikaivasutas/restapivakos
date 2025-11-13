using Solution.Database.Entities;

namespace Solution.DataBase;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
	public DbSet<AccountEntity> Accounts { get; set; }
	public DbSet<ItemEntity> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
