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

            #region GYMKHANA
            modelBuilder.Entity<Facility>()
               .Property(b => b.ModifiedDate)
               .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Gender>()
               .Property(b => b.ModifiedDate)
               .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<HolidayCalendar>()
               .Property(b => b.ModifiedDate)
               .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<TimeSlots>()
               .Property(b => b.ModifiedDate)
               .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<ReservationFees>()
               .Property(b => b.ModifiedDate)
               .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<ScheduledSlots>()
               .Property(b => b.ModifiedDate)
               .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<ScheduledTransaction>()
               .Property(b => b.ModifiedDate)
               .HasDefaultValueSql("GETUTCDATE()");
            #endregion

        }

        public static void DefaultDeleteFilter(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<Data.Action>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<Page>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<Facility>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Gender>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<HolidayCalendar>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<TimeSlots>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<ReservationFees>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<ScheduledSlots>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<ScheduledTransaction>().HasQueryFilter(p => !p.IsDeleted);

        }
    }
}
