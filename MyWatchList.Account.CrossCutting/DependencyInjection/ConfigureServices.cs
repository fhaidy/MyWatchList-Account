using Microsoft.Extensions.DependencyInjection;
using MyWatchList.Account.Services.Services;

namespace MyWatchList.Account.CrossCutting.DependencyInjection
{
    public static class ConfigureServices
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<AccountService>();
        }
    }
}
