namespace Solution.Api.Configurations;

public static class DiConfigurations
{
    public static WebApplicationBuilder ConfigureDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddTransient<IMotorcycleService, MotorcycleService>();

        return builder;
    }
}
