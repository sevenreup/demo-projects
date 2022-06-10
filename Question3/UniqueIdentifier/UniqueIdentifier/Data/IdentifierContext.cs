using Microsoft.EntityFrameworkCore;
using UniqueIdentifier.Entities;

namespace UniqueIdentifier.Data
{
    public class IdentifierContext : DbContext
    {
        public IdentifierContext(DbContextOptions options)
                : base(options)
        { }

        public DbSet<Identity> Identities { get; set; }
    }
}
