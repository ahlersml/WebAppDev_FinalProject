using Microsoft.EntityFrameworkCore;

namespace GenreSchedule.Models
{
    public class GenreScheduleContext : DbContext
    {
        public GenreScheduleContext(DbContextOptions<GenreScheduleContext> options)
            : base(options)
        { }

        public DbSet<Date> Dates { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DateConfig());
            modelBuilder.ApplyConfiguration(new RenterConfig());
            modelBuilder.ApplyConfiguration(new GenreConfig());
        }

    }
}
