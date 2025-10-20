

namespace Solution.DesktopApp.Configurations;

public static class ConfigureDI
{
	public static MauiAppBuilder UseDIConfiguration(this MauiAppBuilder builder)
	{
		builder.Services.AddTransient<MainPageViewModel>();
		builder.Services.AddTransient<MainView>();
		builder.Services.AddTransient<CreateOrEditChocolateViewModel>();
		builder.Services.AddTransient<CreateOrEditChocolateView>();
		builder.Services.AddTransient<CreateOrEditBrandViewModel>();
		builder.Services.AddTransient<CreateOrEditBrandView>();

		builder.Services.AddTransient<ListChocolateViewModel>();
		builder.Services.AddTransient<ListChocolateView>();
		builder.Services.AddTransient<ListBrandViewModel>();
		builder.Services.AddTransient<ListBrandView>();

		builder.Services.AddTransient<IChocolateService, ChocolateService>();
		builder.Services.AddTransient<IBrandService, BrandService>();
        return builder;
	}
}
