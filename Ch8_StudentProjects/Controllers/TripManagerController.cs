using Ch8_StudentProjects.Models.DataLayer;
using Ch8_StudentProjects.Models;
using Ch8_StudentProjects.Models.DomainModels;
using Ch8_StudentProjects.Models.DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace Ch8_StudentProjects.Controllers
{
    public class TripManagerController : Controller
    {
        private Repository<Trip> Trips { get; set; }
        private Repository<Destination> Destinations { get; set; }
        private Repository<Accommodation> Accommodations { get; set; }
        private Repository<Activity> Activities { get; set; }

        public TripManagerController(TripLogConext ctx)
        {
            Trips = new Repository<Trip>(ctx);
            Destinations = new Repository<Destination>(ctx);
            Accommodations = new Repository<Accommodation>(ctx);
            Activities = new Repository<Activity>(ctx);
        }

        [HttpGet]
        public IActionResult Cancel()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("tripmanager/add")]
        public IActionResult Index()
        {
            var vm = new TripViewModel();
            vm.Page = 1;
            vm.Trip = new Trip();
            vm.Accommodations = (List<Accommodation>)Accommodations.List(new QueryOptions<Accommodation>
            {
                OrderBy = a => a.Name!
            });
            vm.Destinations = (List<Destination>)Destinations.List(new QueryOptions<Destination>
            {
                OrderBy = d => d.Name!
            });
            return View("AddPage1", vm);
        }


        [HttpPost]
        public IActionResult Next(TripViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Accommodations = (List<Accommodation>)Accommodations.List(new QueryOptions<Accommodation>
                {
                    OrderBy = a => a.Name!
                });
                vm.Destinations = (List<Destination>)Destinations.List(new QueryOptions<Destination>
                {
                    OrderBy = d => d.Name!
                });
                vm.Activities = (List<Activity>)Activities.List(new QueryOptions<Activity>
                {
                    OrderBy = a => a.Name!
                });
                vm.Page = 2;
                return View("AddPage2", vm);
            }
            else
            {
                vm.Accommodations = (List<Accommodation>)Accommodations.List(new QueryOptions<Accommodation>
                {
                    OrderBy = a => a.Name!
                });
                vm.Destinations = (List<Destination>)Destinations.List(new QueryOptions<Destination>
                {
                    OrderBy = d => d.Name!
                });
                vm.Activities = (List<Activity>)Activities.List(new QueryOptions<Activity>
                {
                    OrderBy = a => a.Name!
                });
                vm.Page = 1;
                return View("AddPage1", vm);
            }
        }

        [HttpPost]
        public IActionResult Save(TripViewModel vm)
        {

            if (vm.SelectedActivitiesId.Count == 0)
            {
                ModelState.AddModelError(nameof(TripViewModel.SelectedActivitiesId), "Atleast 1 Activity Required");
            }
            else if (vm.SelectedActivitiesId.Count > 3)
            {
                ModelState.AddModelError(nameof(TripViewModel.SelectedActivitiesId), "Max of 3 Activity Allowed");
            }
            else
            {
                foreach (var id in vm.SelectedActivitiesId)
                {
                    var activity = Activities.Get(new QueryOptions<Activity>
                    {
                        Where = a => a.ActivityId == id
                    });
                    if (activity != null)
                    {
                        vm.Trip.Activities!.Add(activity);
                    }
                }

                Trips.Insert(vm.Trip);
                Trips.Save();
                return RedirectToAction("Index", "Home");
            }


            vm.Activities = (List<Activity>)Activities.List(new QueryOptions<Activity>
            {
                OrderBy = a => a.Name!
            });
            return View("AddPage2", vm);
            //return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Save()
        {
            return RedirectToAction("Index", "TripManager");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Trips.Delete(new Trip() { TripId = id});
            Trips.Save();
            return RedirectToAction("Index", "Home");
        }
    }
}
