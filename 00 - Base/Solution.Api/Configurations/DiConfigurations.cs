
namespace Solution.Api.Configurations;

public static class DIConfigurations
{
    public static WebApplicationBuilder ConfigureDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddTransient<IChocolateService, ChocolateService>();
        builder.Services.AddTransient<IBrandService, BrandService>();

        return builder;
    }
}
