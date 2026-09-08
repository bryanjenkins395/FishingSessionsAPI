namespace FishingSessionsAPI.Models
{
    public class Catch
    {
        public int Id { get; set; }
        public int FishingSessionId { get; set; }
        public DateTime CaughtAt { get; set; }
        public FishingSession FishingSession { get; set; } = null!;
    }
}
