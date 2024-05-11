namespace OlympGuide.Application.Features.TestData
{
    public interface ITestDataService
    {
        Task<int> CreateTestData();
        Task<int> DeleteTestData();
    }
}
