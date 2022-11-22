using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenreSchedule.Models
{
    internal class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> entity)
        {
            entity.HasData(
               new Genre { GenreId = 1, Title = "Avengers Endgame", genre = "Action", RenterId = 1, DateId = 1},
               new Genre { GenreId = 2, Title = "A Walk to Remember", genre = "Drama", RenterId = 1, DateId = 2},
               new Genre { GenreId = 3, Title = "Scarface", genre = "Action", RenterId = 4, DateId = 4},
               new Genre { GenreId = 4, Title = "Titanic", genre = "Drama", RenterId = 4, DateId = 4},
               new Genre { GenreId = 5, Title = "A Silent Voice", genre = "Anime", RenterId = 2, DateId = 3},
               new Genre { GenreId = 6, Title = "Breaking Bad Season 1", genre = "Tv/Action", RenterId = 2, DateId = 5},
               new Genre { GenreId = 7, Title = "Good Will Hunting", genre = "Drama", RenterId = 5, DateId = 1},
               new Genre { GenreId = 8, Title = "50 First Dates", genre = "Romantic Comedy", RenterId = 5, DateId = 3},
               new Genre { GenreId = 9, Title = "Halloween", genre = "Horror", RenterId = 3, DateId = 4},
               new Genre { GenreId = 10, Title = "Talladega Nights", genre = "Comedy", RenterId = 3, DateId = 5}
            );
            entity.HasOne(c => c.Renter)
                .WithMany(t => t.genres)
                .OnDelete(DeleteBehavior.Restrict);
        }
        
    }

}
