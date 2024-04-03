using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlympGuide.Domain.Abstraction;

namespace OlympGuide.Domain.Features.SportField
{
    public class SportField(): Entity
    {
        public string Name { get; set; } 
        public string Description { get; set; } 
        public float Longitude { get; set; }
        public float Latitude { get; set; }

    }
}
