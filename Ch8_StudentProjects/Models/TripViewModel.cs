using Ch8_StudentProjects.Models.DomainModels;

namespace Ch8_StudentProjects.Models
{
    public class TripViewModel
    {
        public int Page { get; set; } = 1;
        public Trip Trip { get; set; } = new Trip();
        public List<Destination> Destinations { get; set; } = new List<Destination>();

        public List<Accommodation> Accommodations { get; set;} = new List<Accommodation>();
        public List<Activity> Activities { get; set; } = new List<Activity>();

        public List<Activity> SelectedActivities { get; set; } = new List<Activity>(); 
        public List<int> SelectedActivitiesId { get; set; } = new List<int>();

    }
}
