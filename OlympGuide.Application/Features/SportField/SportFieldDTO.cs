using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympGuide.Application.Features.SportField
{
    public class SportFieldDTO
    {
        public Guid id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}
