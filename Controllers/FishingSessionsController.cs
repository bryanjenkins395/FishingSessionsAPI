using FishingSessionsAPI.Enums;
using FishingSessionsAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FishingSessionsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FishingSessionsController : ControllerBase
    {

        private readonly IFishingSessionService _fishingSessionService;

        public FishingSessionsController(IFishingSessionService fishingSessionService)
        {
            _fishingSessionService = fishingSessionService;
        }

        [HttpPost]
        public IActionResult StartSession()
        {
            var session = _fishingSessionService.StartSession();
            return Ok(session);
        }

        [HttpPut("{id}")]
        public IActionResult EndSession(int id)
        {
            var result = _fishingSessionService.EndSession(id);

            if (result.OutCome == EndSessionOutcome.NotFound)
            {
                return NotFound(result.ErrorMessage);
            }

            if (result.OutCome == EndSessionOutcome.AlreadyEnded)
            {
                return Conflict(result.ErrorMessage);
            }

            if (result.OutCome == EndSessionOutcome.Success)
            {
                return Ok();
            }

            return StatusCode(500);


        }

        [HttpGet]
        public IActionResult GetSessionById(int id)
        {
            var session = _fishingSessionService.GetSessionById(id);
            if (session == null)
            {
                return NotFound();
            }
            return Ok(session);
        }
    }
}
