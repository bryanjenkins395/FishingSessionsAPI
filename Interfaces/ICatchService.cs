using FishingSessionsAPI.Models;

namespace FishingSessionsAPI.Interfaces
{
    public interface ICatchService
    {
        Catch LogCatch(int fishingSessionId, DateTime caughtAt);
    }
}
