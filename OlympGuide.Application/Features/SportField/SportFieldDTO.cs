using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympGuide.Application.Features.SportField
{
    public record SportFieldDTO(Guid id, string Name, string Description, float Longitude, float Latitude)
    {    

    }
}
