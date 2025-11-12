using Solution.Core.Interfaces;
using Solution.Services.Services;

namespace Solution.DesktopApp.Configurations;

public static class ConfigureDI
{
	public static MauiAppBuilder UseDIConfiguration(this MauiAppBuilder builder)
	{
		builder.Services.AddTransient<MainPageViewModel>();
		builder.Services.AddTransient<MainPage>();

		builder.Services.AddTransient<IAccountService, AccountService>();
		builder.Services.AddTransient<IItemService, ItemService>();

        return builder;
	}
}
