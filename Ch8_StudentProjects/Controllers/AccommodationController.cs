using Ch8_StudentProjects.Models.DataLayer;
using Ch8_StudentProjects.Models.DataLayer;
using Ch8_StudentProjects.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ch8_StudentProjects.Controllers
{
    public class AccommodationController : Controller
    {
        private Repository<Accommodation> Accommodations { get; set; }

        public AccommodationController(TripLogConext context) => Accommodations = new Repository<Accommodation>(context);

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Message"] = TempData["Message"];
            var accommodations = Accommodations.List(new QueryOptions<Accommodation> { OrderBy = a => a.Name });
            return View(accommodations);
        }

        [HttpGet]
        public IActionResult Cancel()
        {
            return RedirectToAction("Index", "Accommodation");
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                Accommodations.Delete(new Accommodation() { AccommodationId = id });
                Accommodations.Save();
            }
            catch (DbUpdateException e)
            {
                TempData["Message"] = "Accommodation is in use and cannot be DELETED!";
                return RedirectToAction("Index", "Accommodation");
            }
            return RedirectToAction("Index", "Accommodation");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("add", new Accommodation());
        }

        [HttpPost]
        public IActionResult Add(Accommodation accommodation)
        {
            if (ModelState.IsValid)
            {
                Accommodations.Insert(accommodation);
                Accommodations.Save();
                return RedirectToAction("Index", "Accommodation");
            }
            else
            {
                return View("Add", accommodation);
            }
        }



    }
}
