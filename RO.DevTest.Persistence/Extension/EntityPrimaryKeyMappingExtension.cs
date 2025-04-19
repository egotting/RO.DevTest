using Microsoft.EntityFrameworkCore;
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Persistence.Extension;

public static class EntityPrimaryKeyMappingExtension
{
    public static ModelBuilder ConfigurePrimaryKey(this ModelBuilder mb)
    {
        mb.Entity<User>().HasKey(x => x.Id);
        return mb;
    }
}