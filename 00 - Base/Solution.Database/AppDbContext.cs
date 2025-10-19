namespace Solution.DataBase;

public class AppDbContext() : DbContext
{
    public DbSet<BrandEntity> Brands { get; set; }
    public DbSet<ChocolateEntity> Chocolates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

}
