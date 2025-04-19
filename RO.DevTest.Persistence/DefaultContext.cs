using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Persistence.Extension;

namespace RO.DevTest.Persistence;

public class DefaultContext : IdentityDbContext<User>
{

    public DbSet<User> User { get; set; }
    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasPostgresExtension("uuid-ossp");
        builder.ApplyConfigurationsFromAssembly(typeof(DefaultContext).Assembly);
        builder.ConfigurePrimaryKey();
                
        base.OnModelCreating(builder);
    }
}