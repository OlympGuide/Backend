using OlympGuide.Domain.Features.SportField;

namespace OlympGuide.Application.Features.SportField
{

    public static class SportFieldValidation
    {
        private const float MaxLatitude = 90.0F;
        private const float MinLatitude = -90.0F;
        private const float MaxLongitude = 180.0F;
        private const float MinLongitude = -180.0F;

        public static bool CheckSportField(SportFieldType sportFieldToCheck)
        {
            return CheckName(sportFieldToCheck) && CheckCoordinates(sportFieldToCheck);
        }

        private static bool CheckName(SportFieldType sportField)
        {
            return !string.IsNullOrEmpty(sportField.Name);
        }

        private static bool CheckCoordinates(SportFieldType sportField)
        {
            var result = false;

            if (sportField.Latitude <= MaxLatitude && sportField.Latitude >= MinLatitude)
            {
                if (sportField.Longitude <= MaxLongitude && sportField.Longitude >= MinLongitude)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
