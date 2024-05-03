using Microsoft.AspNetCore.Mvc;
using OlympGuide.Infrastructre.Repositories;

namespace OlympGuide.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestDataController(TestDataRepository testDataRepository) : Controller
    {
        private readonly TestDataRepository _testDataRepository = testDataRepository;

        [HttpGet("")]
        public async Task<int> CreateOrRecreateTestData()
        {
            await _testDataRepository.DeleteTestData();
            var amountCreated = await _testDataRepository.CreateTestData();

            return amountCreated;
        }
    }
}
