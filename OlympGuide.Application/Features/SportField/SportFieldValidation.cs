using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympGuide.Application.Features.SportField
{

    public static class SportFieldValidation
    {

        private const float MaxLatitude = 90.0F;
        private const float MinLatitude = -90.0F;
        private const float MaxLongitude = 180.0F;
        private const float MinLongitude = -180.0F;

        public static bool CheckSportFieldRequestDTO(CreateSportFieldRequestDTO sportFieldToCheck)
        {
            bool result = false;
            if (sportFieldToCheck != null)
            {
                result = CheckName(sportFieldToCheck) && CheckCoordinates(sportFieldToCheck);

            }

            return result;
        }

        private static bool CheckName(CreateSportFieldRequestDTO sportFieldRequestDTO)
        {
            bool result = false;
            if (sportFieldRequestDTO.Name != null && !sportFieldRequestDTO.Name.Equals(""))
            {
                result = true;
            }
            return result;
        }

        private static bool CheckCoordinates(CreateSportFieldRequestDTO sportFieldRequestDTO)
        {
            bool result = false;

            if (sportFieldRequestDTO.Latitude <= MaxLatitude && sportFieldRequestDTO.Latitude >= MinLatitude)
            {
                if(sportFieldRequestDTO.Longitude <= MaxLongitude && sportFieldRequestDTO.Longitude >= MinLongitude)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
