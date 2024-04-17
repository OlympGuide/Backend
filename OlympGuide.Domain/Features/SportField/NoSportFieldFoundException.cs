namespace OlympGuide.Domain.Features.SportField
{
    public class NoSportFieldFoundException(Guid id) : Exception(String.Format("Sport field with id: {0} was not found", id.ToString()));
}
