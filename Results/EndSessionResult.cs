using FishingSessionsAPI.Enums;

namespace FishingSessionsAPI.Results
{
    public class EndSessionResult
    {
        public EndSessionOutcome OutCome { get; set; }
        public string? ErrorMessage { get; set; }
        
    }
}
