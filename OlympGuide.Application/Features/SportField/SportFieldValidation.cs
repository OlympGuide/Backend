using OlympGuide.Domain.Features.SportFieldProposal;

namespace OlympGuide.Application.Features.SportField
{

    public static class SportFieldValidation
    {

        private const float MaxLatitude = 90.0F;
        private const float MinLatitude = -90.0F;
        private const float MaxLongitude = 180.0F;
        private const float MinLongitude = -180.0F;

        public static bool CheckSportFieldProposal(SportFieldProposalType sportFieldToCheck)
        {
            if (sportFieldToCheck == null) return false;
            return CheckName(sportFieldToCheck) && CheckCoordinates(sportFieldToCheck);
        }

        private static bool CheckName(SportFieldProposalType sportFieldProposal)
        {
            if (sportFieldProposal.SportFieldName.Equals(string.Empty))
            {
                return false;
            }
            return true;
        }

        private static bool CheckCoordinates(SportFieldProposalType sportFieldProposal)
        {
            var result = false;

            if (sportFieldProposal.SportFieldLatitude <= MaxLatitude && sportFieldProposal.SportFieldLatitude >= MinLatitude)
            {
                if (sportFieldProposal.SportFieldLongitude <= MaxLongitude && sportFieldProposal.SportFieldLongitude >= MinLongitude)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
