//using Ch8_StudentProjects.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace Ch8_StudentProjects.Controllers
//{
//    public class AddTripsController : Controller
//    {

//        public TripLogConext Context { get; set; }

//        public AddTripsController(TripLogConext ctx)
//        {
//            Context = ctx;
//        }

//        [HttpPost]
//        public IActionResult Add(TripViewModel vm)
//        {
//            if (vm.Page == 1)
//            {
//                if (ModelState.IsValid)
//                {
//                    TempData[nameof(Trip.DestinationId)] = vm.Trip.DestinationId;
//                    TempData[nameof(Trip.Accomodation)] = vm.Trip.Accomodation;
//                    TempData[nameof(Trip.StartDate)] = vm.Trip.StartDate;
//                    TempData[nameof(Trip.EndDate)] = vm.Trip.EndDate;
//                    return RedirectToAction("Index", new { id = "Page2" });
//                }
//                else
//                {
//                    return View("Page1", vm);
//                }
//            }
//            else if (vm.Page == 2)
//            {
//                TempData[nameof(Trip.AccomodationPhone)] = vm.Trip.AccomodationPhone;
//                TempData[nameof(Trip.AccomodationEmail)] = vm.Trip.AccomodationEmail;
//                return RedirectToAction("Index", new { id = "Page3" });
//            }
//            else if (vm.Page == 3)
//            {
//                vm.Trip.DestinationId = (int)TempData[nameof(Trip.DestinationId)]!;
//                vm.Trip.Accomodation = TempData[nameof(Trip.Accomodation)]?.ToString()!;
//                vm.Trip.StartDate = (DateTime)TempData[nameof(Trip.StartDate)]!;
//                vm.Trip.EndDate = (DateTime)TempData[nameof(Trip.EndDate)]!;
//                vm.Trip.AccomodationPhone = TempData[nameof(Trip.AccomodationPhone)]?.ToString()!;
//                vm.Trip.AccomodationEmail = TempData[nameof(Trip.AccomodationEmail)]?.ToString()!;

//                Context.Trips.Add(vm.Trip);
//                Context.SaveChanges();
//                TempData["message"] = "Trip Added";
//                return RedirectToAction("Index", "Home");

//            }
//            else
//            {
//                return RedirectToAction("Index", "Home");
//            }

//        }

//        [HttpGet]
//        [Route("/addtrips/cancel")]
//        public IActionResult Cancel()
//        {
//            TempData.Clear();
//            return RedirectToAction("Index", "Home");
//        }

//        [HttpGet]
//        [Route("/addtrips/{id?}")]
//        public IActionResult Index(string id = "")
//        {
//            TripViewModel vm = new TripViewModel();
//            vm.Page = 1;
//            if (id.ToLower() == "page2")
//            {
//                vm.Page = 2;
//                vm.Trip.Accomodation = TempData.Peek(nameof(Trip.Accomodation))?.ToString()!;
//                ViewBag.SubHeader = TempData.Peek(nameof(Trip.Accomodation))?.ToString()!;

//                return View("Page2", vm);
//            }
//            else if (id.ToLower() == "page3")
//            {
//                vm.Page = 3;
//                vm.Trip.DestinationId = (int)TempData.Peek(nameof(Trip.DestinationId))!;
//                return View("Page3", vm);
//            }
//            else
//            {
//                vm.Page = 1;
//                vm.Destinations = Context.Destinations.OrderBy(d => d.Name).ToList();
//                return View("Page1", vm);
//            }

//        }

//    }
//}
