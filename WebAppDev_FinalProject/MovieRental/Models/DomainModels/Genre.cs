using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GenreSchedule.Models
{
    public class Genre
    {
        public int GenreId { get; set; }                    // PK

        [StringLength(200, ErrorMessage = "Title may not exceed 200 characters.")]
        [Required(ErrorMessage = "Please enter a genre.")]
        public string Title { get; set; }

        [StringLength(200, ErrorMessage = "Genre may not exceed 200 characters.")]
        [Required(ErrorMessage = "Please enter a genre.")]
        public string genre { get; set; }

        /*[Display(Name = "Time")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter numbers only for return time.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Return time must be 4 characters long.")]
        [Required(ErrorMessage = "Please enter a return time (in military time format).")]
        public string MilitaryTime { get; set; }
        */

        public int RenterId { get; set; }                  // Foreign key property
        public Renter Renter { get; set; }                // Navigation property

        public int DateId { get; set; }                      // Foreign key property
        public DateTime Date { get; set; }                        // Navigation property
    
    
        
    
    
    }
   
}
