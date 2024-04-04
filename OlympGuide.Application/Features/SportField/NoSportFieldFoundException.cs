using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OlympGuide.Application.Features.SportField
{
    public class NoSportFieldFoundException(Guid id) : Exception(String.Format("Sport field with id: {0} was not found", id.ToString()))
    {
    }
}
