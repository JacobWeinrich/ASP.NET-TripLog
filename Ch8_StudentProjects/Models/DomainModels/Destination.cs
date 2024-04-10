using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ch8_StudentProjects.Models.DomainModels
{
    public class Destination
    {
        public Destination() => Trips = new List<Trip>();

        public int DestinationId { get; set; }

        [Required(ErrorMessage = "Destination Name is Required!")]
        public string? Name { get; set; }

        public ICollection<Trip>? Trips { get; set; }
    }
}
