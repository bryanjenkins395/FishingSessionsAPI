namespace FishingSessionsAPI.Models
{
    public class FishingSession
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public List<Catch> Catches { get; set; } = new();
    }
}
