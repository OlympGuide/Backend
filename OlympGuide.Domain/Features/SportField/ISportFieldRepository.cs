namespace OlympGuide.Domain.Features.SportField
{
    public interface ISportFieldRepository
    {
        public Task<List<SportFieldType>> GetAllSportFields();
        public Task<SportFieldType> GetSportFieldById(Guid sportFieldId);
        public Task<SportFieldType> AddSportField(SportFieldType sportFieldToAdd);
        public Task<List<SportFieldType>> GetAllSportFielsByCategory(SportFieldCategory catergory);
    }
}
