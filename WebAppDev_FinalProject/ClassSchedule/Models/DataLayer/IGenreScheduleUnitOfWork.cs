using ClassSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenreSchedule.Models
{
    interface IGenreScheduleUnitOfWork
    {
        Repository<Genre> genres { get; }

        Repository<Renter> renters { get; }

        Repository<Date> dates { get; }

       
        void Save();
    }
}
