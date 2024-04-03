using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympGuide.Application.Features.SportField
{
    public class NoSportFieldFoundException: Exception
    {
        public NoSportFieldFoundException() : base("No sport field was found.")
        {
        }
    }
}
