using CodeChallengeBF.Data;
using CodeChallengeBF.Data.Contract;
using CodeChallengeBF.Service.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace CodeChallengeBF.Service
{
    public static class Extensions
    {
        /// <summary>
        /// Register the required dependencies
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServices(this IServiceCollection services )
        {
            // Using AutoMap to decouple the layers
            // So controllers do not need to know the data layer etc
            services.AddAutoMapper( typeof( MapperProfile ) );

            // Quick mem cache
            // To enhance the performance also to avoid storing redundant data
            services.AddSingleton<ICache, SimpleMemCache>();
            // JSON file storage
            services.AddSingleton<ITestFormRepository, TestFormJsonFile>();

            services.AddTransient<ITestFormService, TestFormService>();
        }
    }
}
