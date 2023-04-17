using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SavePage.Handlers;

namespace SavePage
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSavePageClient(this IServiceCollection services)
        {
            services.AddOptions<SavePageOptions>();
            AddHttpClientWithHandlers(services);
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.Configure<SavePageOptions>(configuration.GetSection(nameof(SavePageOptions)));
            return services;
        }

        public static IServiceCollection AddSavePageClient(this IServiceCollection services, Action<SavePageOptions> setupAction)
        {
            services.AddOptions<SavePageOptions>().Configure(setupAction);
            AddHttpClientWithHandlers(services);
            return services;
        }

        private static void AddHttpClientWithHandlers(IServiceCollection services)
        {
            services
                .AddScoped<LoggingHandler>()
                .AddScoped<ExceptionHandler>();

            services
                .AddHttpClient<SavePageClient>()
                .AddHttpMessageHandler<LoggingHandler>()
                .AddHttpMessageHandler<ExceptionHandler>();
        }
    }
}