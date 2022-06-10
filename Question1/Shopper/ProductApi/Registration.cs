using ProductApi.Repository;

namespace ProductApi
{
    public static class Registration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
