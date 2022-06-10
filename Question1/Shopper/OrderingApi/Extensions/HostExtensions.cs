using Microsoft.EntityFrameworkCore;
using OrderingApi.Data;

namespace OrderingApi.Extensions
{
    public static class HostExtensions
    {
        public static WebApplication MigrateDatabase(this WebApplication webApp, int? retry = 0)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<OrderContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            }
            return webApp;
        }
    }
}
