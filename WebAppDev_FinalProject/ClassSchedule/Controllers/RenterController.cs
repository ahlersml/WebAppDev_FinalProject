using Microsoft.AspNetCore.Mvc;
using GenreSchedule.Models;
using ClassSchedule.Models;

namespace GenreSchedule.Controllers
{
    public class RenterController : Controller
    {
        private Repository<Renter> Renters { get; set; }
        public RenterController(GenreScheduleContext ctx) => Renters = new Repository<Renter>(ctx);

        public ViewResult Index()
        {
            var options = new QueryOptions<Renter> {
                OrderBy = t => t.LastName
            };
            return View(Renters.List(options));
        }

        [HttpGet]
        public ViewResult Add() => View();

        [HttpPost]
        public IActionResult Add(Renter Renter)
        {
            if (ModelState.IsValid) {
                Renters.Insert(Renter);
                Renters.Save();
                return RedirectToAction("Index");
            }
            else{
                return View(Renter);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            return View(Renters.Get(id));
        }

        [HttpPost]
        public RedirectToActionResult Delete(Renter Renter)
        {
            Renters.Delete(Renter);
            Renters.Save();
            return RedirectToAction("Index");
        }
    }
}