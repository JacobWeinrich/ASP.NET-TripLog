using Ch8_StudentProjects.Models.DataLayer;
using Ch8_StudentProjects.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace Ch8_StudentProjects.Controllers
{
    public class ActivityController : Controller
    {
        private Repository<Activity> Activities { get; set; }

        public ActivityController(TripLogConext context) => Activities = new Repository<Activity>(context);

        public IActionResult Index()
        {
            var activities = Activities.List(new QueryOptions<Activity> { OrderBy = a => a.Name });
            return View(activities);
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index", "Activity");
        }

        public IActionResult Delete(int id)
        {
            Activities.Delete(new Activity() { ActivityId = id });
            Activities.Save();
            return RedirectToAction("Index", "Activity");
        }

        public IActionResult Add()
        {
            return View("add", new Activity());
        }

        [HttpPost]
        public IActionResult Add(Activity activity)
        {
            if (ModelState.IsValid)
            {
                Activities.Insert(activity);
                Activities.Save();
                return RedirectToAction("Index", "Activity");
            }
            else
            {
                return View("Add", activity);
            }
        }


    }
}
