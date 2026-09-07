using FishingSessionsAPI.Models;

namespace FishingSessionsAPI.Interfaces
{
    public interface IFishingSessionService
    {
        FishingSession StartSession();
        FishingSession? EndSession(int id);

        FishingSession? GetSessionById(int id);
    }
}
