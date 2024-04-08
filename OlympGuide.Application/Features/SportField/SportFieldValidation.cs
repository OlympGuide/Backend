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
            
            return CheckName(sportFieldToCheck) && CheckCoordinates(sportFieldToCheck);
        }

        private static bool CheckName(CreateSportFieldRequestDTO sportFieldRequestDTO)
        {
            return !sportFieldRequestDTO.Name.Equals(string.Empty);
        }

        private static bool CheckCoordinates(CreateSportFieldRequestDTO sportFieldRequestDTO)
        {
            var result = false;

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
