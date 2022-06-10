using Npgsql;

namespace ProductApi.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host, int? retry = 0)
        {
            return host;
        }
    }
}
