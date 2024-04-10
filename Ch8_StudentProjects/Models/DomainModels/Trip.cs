using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ch8_StudentProjects.Models.DomainModels
{
    public class Trip
    {
        public Trip()
        {
            Activities = new List<Activity>();
        }

        public int TripId { get; set; }

        [Required(ErrorMessage = "Destination is Required")]
        public int? DestinationId { get; set; }
        [ValidateNever]
        public Destination? Destination { get; set; }


        [Required(ErrorMessage = "Accomodation is Required")]
        public int? AccommodationId { get; set; }
        [ValidateNever]
        public Accommodation? Accommodation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Activity>? Activities { get; set; }

    }
}
