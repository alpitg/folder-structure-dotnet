using Structure.Data;
using Microsoft.EntityFrameworkCore;

namespace Structure.Domain
{
    public static class DefaultEntityMappingExtension
    {
        public static void DefaultMappingValue(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>()
               .Property(b => b.ModifiedDate)
               .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Data.Action>()
               .Property(b => b.ModifiedDate)
               .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Page>()
                .Property(b => b.ModifiedDate)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<User>()
                .Property(b => b.ModifiedDate)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Role>()
                .Property(b => b.ModifiedDate)
                .HasDefaultValueSql("GETUTCDATE()");

        }

        public static void DefaultDeleteFilter(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<Data.Action>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<Page>().HasQueryFilter(p => !p.IsDeleted);

        }
    }
}
