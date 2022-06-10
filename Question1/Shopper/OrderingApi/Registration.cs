using OrderingApi.Repositories;

namespace OrderingApi
{
    public static class Registration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
