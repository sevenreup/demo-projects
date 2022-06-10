using UniqueIdentifier.Repositories;
using UniqueIdentifier.Serivices;

namespace UniqueIdentifier
{
    public static class Registration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IIdentityRepository, IdentityRepository>();
            services.AddScoped<IUniqueIDService, UniqueIDService>();

            return services;
        }
        }
}
