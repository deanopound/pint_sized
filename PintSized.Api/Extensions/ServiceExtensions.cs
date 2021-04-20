using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PintSized.Api.Services;
using Repository;

namespace PintSized.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        public static void RegisterDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            string mongoConnectionString = Configuration.GetConnectionString("MongoConnectionString");
            services.AddTransient<IShortURLRepository>(s => new ShortURLRepository(mongoConnectionString, "Url", "ShortUrl"));
            services.AddTransient<IShortURLService, ShortURLService>();
        }
    }
}