using FishingSessionsAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FishingSessionsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CatchController : ControllerBase
    {
        private readonly ICatchService _catchService;

        public CatchController(ICatchService catchService)
        {
            _catchService = catchService;
        }

        [HttpPost]
        public IActionResult LogCatch(int fishingSessionId, DateTime caughtAt)
        {
            var catchRecord = _catchService.LogCatch(fishingSessionId, caughtAt);

            return Ok(catchRecord);
        }


    }
}
