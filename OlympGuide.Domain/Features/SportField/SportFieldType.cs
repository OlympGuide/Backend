using OlympGuide.Domain.Abstraction;

namespace OlympGuide.Domain.Features.SportField
{
    public class SportFieldType : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}
