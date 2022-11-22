using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenreSchedule.Models
{
    internal class DateConfig : IEntityTypeConfiguration<Date>
    {
        public void Configure(EntityTypeBuilder<Date> entity)
        {
            entity.HasData(
               new Date { DateId = 1, Name = "Monday" },
               new Date { DateId = 2, Name = "02/02/2022" }, 
               new Date { DateId = 3, Name = "Wednesday" },
               new Date { DateId = 4, Name = "Thursday" },
               new Date { DateId = 5, Name = "Friday" },
               new Date { DateId = 6, Name = "Saturday" },
               new Date { DateId = 7, Name = "Sunday" }
            );
        }
    }

}
