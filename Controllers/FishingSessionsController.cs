using Microsoft.AspNetCore.Mvc;
using FishingSessionsAPI.Interfaces;

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

        [HttpPut]
        public IActionResult EndSession(int id)
        {
            var session = _fishingSessionService.EndSession(id);
            if (session == null)
            {
                return NotFound();
            }
            return Ok(session);
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
