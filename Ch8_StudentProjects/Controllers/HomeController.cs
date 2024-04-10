using Ch8_StudentProjects.Models.DataLayer;
using Ch8_StudentProjects.Models.DataLayer;
using Ch8_StudentProjects.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Ch8_StudentProjects.Controllers
{
    public class HomeController : Controller
    {

        private Repository<Trip> Trips { get; set; }

        public HomeController(TripLogConext ctx)
        {
            Trips = new Repository<Trip>(ctx);
        }



        public IActionResult Index()
        {
            ViewBag.SubHeader = TempData["message"];
            var trips = Trips.List(new QueryOptions<Trip>
            {
                OrderBy = t => t.TripId,
                Includes = "Accommodation,Destination,Activities",
            });
            return View(trips);
        }



    }
}
