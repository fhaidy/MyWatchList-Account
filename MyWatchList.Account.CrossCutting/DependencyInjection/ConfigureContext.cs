using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyWatchList.Account.Data.Context;

namespace MyWatchList.Account.CrossCutting.DependencyInjection
{
    public static class ConfigureContext
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<AccountContext>();
        }
    }
}
