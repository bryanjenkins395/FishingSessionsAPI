namespace FishingSessionsAPI.Results
{
    public class EndSessionResult
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public int? StatusCode { get; set; }
    }
}
