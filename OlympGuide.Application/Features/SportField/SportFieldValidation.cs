using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympGuide.Application.Features.SportField
{
    public class SportFieldValidation
    {
        public Boolean checkSportFieldRequestDTO(CreateSportFieldRequestDTO sportFieldToCheck)
        {
            Boolean result = false;
            if (sportFieldToCheck != null)
            {
                result = checkName(sportFieldToCheck) && checkCoordinates(sportFieldToCheck);

            }

            return result;
        }

        private Boolean checkName(CreateSportFieldRequestDTO sportFieldRequestDTO)
        {
            Boolean result = false;
            if (sportFieldRequestDTO.Name != null && !sportFieldRequestDTO.Name.Equals(""))
            {
                result = true;
            }
            return result;
        }

        private Boolean checkCoordinates(CreateSportFieldRequestDTO sportFieldRequestDTO)
        {
            Boolean result = false;

            if (sportFieldRequestDTO.Latitude <= 90.0 && sportFieldRequestDTO.Latitude >= -90.0)
            {
                if(sportFieldRequestDTO.Longitude <= 180.0 && sportFieldRequestDTO.Longitude >= -180 - 0)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
