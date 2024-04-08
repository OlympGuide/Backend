namespace OlympGuide.Domain.Features.SportField
{
    public interface ISportFieldRepository
    {
        public Task<List<SportFieldType>> GetAllSportFields();
        public Task<SportFieldType> GetSportFieldById(Guid sportFieldID);
        public Task<SportFieldType> AddSportField(SportFieldType sportFieldToAdd);
    }
}
