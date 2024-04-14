namespace OlympGuide.Application.Features.SportFieldProposal
{
    public class NoSportFieldProposalFoundException(Guid id) : Exception(String.Format("Sport field proposal with id: {0} was not found", id.ToString()));
}
