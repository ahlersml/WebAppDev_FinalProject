using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GenreSchedule.Models
{
    public class Date
    {
        public int DateId { get; set; }                     // PK

        // no error messages included bc users won't be entering - this is so 
        // EF will generate a non-null nvarchar with length shorter than max
        [StringLength(10)]  
        [Required()]
        public string Name { get; set; }

        public ICollection<Genre> Genres { get; set; }    // Navigation property
    }
}
