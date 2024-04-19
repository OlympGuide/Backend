using OlympGuide.Domain.Abstraction;

namespace OlympGuide.Domain.Features.SportField
{
    public class SportFieldType : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
