using Microsoft.Extensions.DependencyInjection;
using MyWatchList.Account.Data.Repository;
using MyWatchList.Account.Services.Services;

namespace MyWatchList.Account.CrossCutting.DependencyInjection
{
    public static class ConfigureServices
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<AccountRepository>();
            serviceCollection.AddTransient<AccountService>();
            serviceCollection.AddTransient(typeof(TokenService));
        }
    }
}
