using Microsoft.EntityFrameworkCore;
using UniqueIdentifier.Data;

namespace UniqueIdentifier.Extensions
{
    public static class ApplicationExtensions
    {
        public static WebApplication MigrateDatabase(this WebApplication webApp, int? retry = 0)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<IdentifierContext>())
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
