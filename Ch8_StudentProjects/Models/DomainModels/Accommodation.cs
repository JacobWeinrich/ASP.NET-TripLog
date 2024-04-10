using System.ComponentModel.DataAnnotations;

namespace Ch8_StudentProjects.Models.DomainModels
{
    public class Accommodation
    {
        public int AccommodationId { get; set; }
        public string? Name { get; set; }
        public string? AccommodationPhone { get; set; }
        public string? AccommodationEmail { get; set; }

        public ICollection<Trip>? Trips { get; set; }

    }
}
