using FishingSessionsAPI.Interfaces;
using FishingSessionsAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FishingSessionsAPI.Services
{
    public class FishingSessionService : IFishingSessionService
    {
        private readonly List<FishingSession> _sessions = new();
        public FishingSession StartSession()
        {
            var session = new FishingSession
            {
                Id = _sessions.Count + 1,
                StartTime = DateTime.Now,
                EndTime = null
            };

            _sessions.Add(session);
            return session;
        }

        public FishingSession EndSession(int id)
        {
            var session = _sessions.FirstOrDefault(s => s.Id == id);

            if (session == null)
            {
                return null;
            }

            session.EndTime = DateTime.Now;

            return session;
        }

        public FishingSession? GetSessionById(int id)
        {
            return _sessions.FirstOrDefault(s => s.Id == id);    
        }
    }
}
