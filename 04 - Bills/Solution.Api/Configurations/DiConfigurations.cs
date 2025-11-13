using Solution.Services.Services;
using System.Runtime.CompilerServices;

namespace Solution.Api.Configurations
{
    public static class DiConfigurations
    {
        public static WebApplicationBuilder ConfigureDI(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddTransient<IAccountService, AccountService>();
            builder.Services.AddTransient<IItemService, ItemService>();

            return builder;
        }
    }
}
