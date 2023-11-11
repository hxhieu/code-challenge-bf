using CodeChallengeBF.Service.Contract;
using CodeChallengeBF.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallengeBF.Controllers
{
    [ApiController]
    [Route( "[controller]" )]
    public class TestFormController : ControllerBase
    {
        private readonly ILogger<TestFormController> _logger;
        private readonly ITestFormService _testFormService;

        public TestFormController( ILogger<TestFormController> logger, ITestFormService testFormService )
        {
            _logger = logger;
            _testFormService = testFormService;
        }

        [HttpPost]
        public async Task<IActionResult> Post( TestFormModel value )
        {
            // TestFormService utilises a cache, so it won't insert same form to the storag
            await _testFormService.Upsert( value );
            _logger.LogInformation( "Value saved to -> {0}", _testFormService.RepoType );
            return Ok();
        }
    }
}