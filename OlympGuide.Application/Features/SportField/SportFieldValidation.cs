namespace OlympGuide.Application.Features.SportField
{

    public static class SportFieldValidation
    {

        private const float MaxLatitude = 90.0F;
        private const float MinLatitude = -90.0F;
        private const float MaxLongitude = 180.0F;
        private const float MinLongitude = -180.0F;

        public static bool CheckSportFieldRequestDto(CreateSportFieldRequestDto? sportFieldToCheck)
        {
            if (sportFieldToCheck == null) return false;
            return CheckName(sportFieldToCheck) && CheckCoordinates(sportFieldToCheck);
        }

        private static bool CheckName(CreateSportFieldRequestDto sportFieldRequestDTO)
        {
           if(sportFieldRequestDTO.Name.Equals(string.Empty))
            {
                return false;
            }
           return true;
        }

        private static bool CheckCoordinates(CreateSportFieldRequestDto sportFieldRequestDto)
        {
            var result = false;

            if (sportFieldRequestDto.Latitude <= MaxLatitude && sportFieldRequestDto.Latitude >= MinLatitude)
            {
                if(sportFieldRequestDto.Longitude <= MaxLongitude && sportFieldRequestDto.Longitude >= MinLongitude)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
