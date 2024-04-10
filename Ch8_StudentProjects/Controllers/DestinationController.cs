using Ch8_StudentProjects.Models.DataLayer;
using Ch8_StudentProjects.Models.DataLayer;
using Ch8_StudentProjects.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ch8_StudentProjects.Controllers
{
    public class DestinationController : Controller
    {
        private Repository<Destination> Destinations { get; set; }

        public DestinationController(TripLogConext context) => Destinations = new Repository<Destination>(context);

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Message"] = TempData["Message"];
            var destinations = Destinations.List(new QueryOptions<Destination> { OrderBy = d => d.Name });
            return View(destinations); 
        }

        [HttpGet]
        public IActionResult Cancel()
        {
            return RedirectToAction("Index", "Destination");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                Destinations.Delete(new Destination() { DestinationId = id });
                Destinations.Save();
            } catch(DbUpdateException e)
            {
                TempData["Message"] = "Destination is in use and cannot be DELETED!";
                return RedirectToAction("Index", "Destination");
            }
            return RedirectToAction("Index", "Destination");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("add", new Destination());
        }
        [HttpPost]
        public IActionResult Add(Destination destination)
        {
            if (ModelState.IsValid)
            {
                Destinations.Insert(destination);
                Destinations.Save();
                return RedirectToAction("Index", "Destination");
            }
            else
            {
                return View("Add", destination);
            }
        }
    }
}
