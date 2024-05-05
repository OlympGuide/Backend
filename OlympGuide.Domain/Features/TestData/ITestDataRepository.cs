using OlympGuide.Domain.Features.Reservation;
using OlympGuide.Domain.Features.SportField;
using OlympGuide.Domain.Features.SportFieldProposal;
using OlympGuide.Domain.Features.User;

namespace OlympGuide.Domain.Features.TestData;

public interface ITestDataRepository
{
    Task<int> CreateTestData(List<UserProfile> users, List<SportFieldType> sportFields, List<SportFieldProposalType> sportFieldProposals, List<ReservationType> reservations);
    Task<int> DeleteTestData();
}