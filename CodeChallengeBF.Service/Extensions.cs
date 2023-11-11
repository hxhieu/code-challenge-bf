using CodeChallengeBF.Data;
using CodeChallengeBF.Data.Contract;
using CodeChallengeBF.Service.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace CodeChallengeBF.Service
{
    public static class Extensions
    {
        public static void RegisterServices(this IServiceCollection services )
        {
            services.AddAutoMapper( typeof( MapperProfile ) );

            // Quick mem cache
            services.AddSingleton<ICache, SimpleMemCache>();
            // JSON file storage
            services.AddSingleton<ITestFormRepository, TestFormJsonFile>();
            services.AddTransient<ITestFormService, TestFormService>();
        }
    }
}
