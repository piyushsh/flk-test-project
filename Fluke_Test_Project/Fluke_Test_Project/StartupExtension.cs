using Fluke_Test_Project.Domain.EventSorting;
using Fluke_Test_Project.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Fluke_Test_Project
{
    internal static class StartUpExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IEonetRepo, EonetRepo>();

            return services;
        }

        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IEventSortingFactory, EventSortingFactory>();

            services.AddTransient<IEventSorting, DateEventSorting>();
            services.AddTransient<IEventSorting, StatusEventSorting>();
            services.AddTransient<IEventSorting, CategoryEventSorting>();

            return services;
        }

        public static IServiceCollection AddCors(this IServiceCollection services, string allowSpecificOrigins)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(allowSpecificOrigins,
                    builder =>
                    {
                        builder
                            .WithOrigins()
                            .AllowAnyOrigin();
                    });
            });

            return services;
        }
    }
}
