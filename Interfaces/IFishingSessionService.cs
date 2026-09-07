using FishingSessionsAPI.Models;
using FishingSessionsAPI.Results;

namespace FishingSessionsAPI.Interfaces
{
    public interface IFishingSessionService
    {
        FishingSession StartSession();
        EndSessionResult EndSession(int id);

        FishingSession? GetSessionById(int id);
    }
}
