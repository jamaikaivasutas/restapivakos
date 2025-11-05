


namespace Solution.DesktopApp.Configurations;
public static class ConfigureSQLSever
{
    public static MauiAppBuilder UseMsSqlServer(this MauiAppBuilder builder)
    {
        string connectionString = builder.Configuration.GetConnectionString("MvcMoviecontext");

        ArgumentNullException.ThrowIfNull(connectionString);

        builder.Services.AddDbContext<AppDbContext>(options =>
         options.UseSqlServer(connectionString));

        return builder;
    }
}
