using Solution.Domain.Database.Entities;

namespace Solution.Domain.Database.Builders;

internal static class UserEntityModelBuilder
{
    public static void ConfigureUser(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(x => x.Id).IsUnique();

            entity.Property(x => x.FullName).HasColumnName("FullName").HasMaxLength(255).HasColumnName("FullName").IsRequired();
            entity.Property(x => x.RegisteredAtUtc).HasColumnName("RegisteredAt").IsRequired();
        });
    }
}
