using Microsoft.AspNetCore.Mvc;
using OlympGuide.Application.Features.TestData;

namespace OlympGuide.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestDatasController(ITestDataService testDataService) : Controller
    {
        private readonly ITestDataService _testDataService = testDataService;

        [HttpPost("")]
        public async Task<int> CreateOrRecreateTestData()
        {
            await _testDataService.DeleteTestData();
            var amountCreated = await _testDataService.CreateTestData();

            return amountCreated;
        }
    }
}
