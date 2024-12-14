namespace Main_Application.Models
{
    public class Feature
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string RequiredLicenseLevel { get; set; }

    }
}
