namespace Ch8_StudentProjects.Models.DomainModels
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string? Name { get; set; }

        public ICollection<Trip>? Trips { get; set; }

    }
}
