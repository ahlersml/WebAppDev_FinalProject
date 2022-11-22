using Microsoft.AspNetCore.Mvc;
using GenreSchedule.Models;
using ClassSchedule.Models;

namespace GenreSchedule.Controllers
{
    public class HomeController : Controller
    {
        
        private GenreScheduleUnitOfWork genreScheduleUnitOfWork { get; }

        public HomeController(GenreScheduleContext ctx)
        {
            genreScheduleUnitOfWork = new GenreScheduleUnitOfWork(ctx);
        }

        public ViewResult Index(int id)
        {
            // options for Dates query
            var DateOptions = new QueryOptions<Date> { 
                OrderBy = d => d.DateId
            };

            // options for Genres query
            var GenreOptions = new QueryOptions<Genre> {
                Includes = "Renter"
            };
            // order by Date if no filter. Otherwise, filter by Date and order by time.
            if (id == 0) {
                GenreOptions.OrderBy = c => c.DateId;
            }
            else {
                GenreOptions.Where = c => c.DateId == id;
                GenreOptions.ThenOrderBy = c => c.Date;

                
            }

            // execute queries
            ViewBag.Dates = genreScheduleUnitOfWork.dates.List(DateOptions);
            return View(genreScheduleUnitOfWork.genres.List(GenreOptions));
        }
    }
}
