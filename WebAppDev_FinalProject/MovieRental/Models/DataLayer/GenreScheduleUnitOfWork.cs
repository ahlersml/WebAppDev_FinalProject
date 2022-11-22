using ClassSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenreSchedule.Models
{
    public class GenreScheduleUnitOfWork : IGenreScheduleUnitOfWork
    {
        public Repository<Genre> genres { get; }
        public Repository<Renter> renters { get;}
        public Repository<Date> dates { get; }
        public GenreScheduleContext _context;

        public GenreScheduleUnitOfWork(GenreScheduleContext ctx)
        {
            _context = ctx;
            genres = new Repository<Genre>(ctx);
            renters = new Repository<Renter>(ctx);
            dates = new Repository<Date>(ctx);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
