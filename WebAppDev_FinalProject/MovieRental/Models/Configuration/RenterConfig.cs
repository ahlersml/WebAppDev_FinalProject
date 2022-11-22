using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenreSchedule.Models
{
    internal class RenterConfig : IEntityTypeConfiguration<Renter>
    {
        public void Configure(EntityTypeBuilder<Renter> entity)
        {
            entity.HasData(
               new Renter { RenterId = 1, FirstName = "Anne", LastName = "Sullivan" },
               new Renter { RenterId = 2, FirstName = "Maria", LastName = "Montessori" },
               new Renter { RenterId = 3, FirstName = "Martin Luther", LastName = "King" },
               new Renter { RenterId = 4, FirstName = "", LastName = "Aristotle" },
               new Renter { RenterId = 5, FirstName = "Jaime", LastName = "Escalante" }
            );
        }
    }

}
