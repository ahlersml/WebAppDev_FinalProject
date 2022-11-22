using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GenreSchedule.Models;
using ClassSchedule.Models;

namespace GenreSchedule.Controllers
{
    public class GenreController : Controller
    {
       
        private GenreScheduleUnitOfWork genreScheduleUnitOfWork { get; }

        public GenreController(GenreScheduleContext ctx)
        {
            genreScheduleUnitOfWork = new GenreScheduleUnitOfWork(ctx);
        }


        public RedirectToActionResult Index() => RedirectToAction("Index", "Home");

        [HttpGet]
        public ViewResult Add()
        {
            this.LoadViewBag("Add");
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            this.LoadViewBag("Edit");
            var c = this.GetGenre(id);
            return View("Add", c);
        }

        [HttpPost]
        public IActionResult Add(Genre c)
        {
            if (ModelState.IsValid) {
                if (c.GenreId == 0)
                    genreScheduleUnitOfWork.genres.Insert(c);
                else
                    genreScheduleUnitOfWork.genres.Update(c);
                genreScheduleUnitOfWork.genres.Save();
                return RedirectToAction("Index", "Home");
            }
            else {
                string operation = (c.GenreId == 0) ? "Add" : "Edit";
                this.LoadViewBag(operation);
                return View();
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var c = this.GetGenre(id);
            return View(c);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Genre c)
        {
            genreScheduleUnitOfWork.genres.Delete(c);
            genreScheduleUnitOfWork.genres.Save();
            return RedirectToAction("Index", "Home");
        }

        // private helper methods
        private Genre GetGenre(int id)
        {
            var genreOptions = new QueryOptions<Genre> {
                Includes = "Renter",
                Where = c => c.GenreId == id
            };
            var list = genreScheduleUnitOfWork.genres.List(genreOptions);

            // return first Class or blank Class if null
            return list.FirstOrDefault();
        }
        private void LoadViewBag(string operation)
        {
            ViewBag.Dates = genreScheduleUnitOfWork.dates.List(new QueryOptions<Date> {
                OrderBy = d => d.DateId
            });
            ViewBag.Renters = genreScheduleUnitOfWork.renters.List(new QueryOptions<Renter> {
                OrderBy = t => t.LastName
            });
            ViewBag.Operation = operation;
        }
    }
}