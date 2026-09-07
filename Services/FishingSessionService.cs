using FishingSessionsAPI.Data;
using FishingSessionsAPI.Interfaces;
using FishingSessionsAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FishingSessionsAPI.Services
{
    public class FishingSessionService : IFishingSessionService
    {
        private readonly FishingDbContext _context;

        public FishingSessionService(FishingDbContext context)
        {
            _context = context;
        }
        public FishingSession StartSession()
        {
            var session = new FishingSession
            {                
                StartTime = DateTime.Now,
                EndTime = null
            };

            _context.FishingSessions.Add(session);
            _context.SaveChanges();
            return session;
        }

        public FishingSession EndSession(int id)
        {
            var session = GetSessionById(id);

            if (session == null)
            {
                return null;
            }

            session.EndTime = DateTime.Now;

            _context.SaveChanges();

            return session;
        }

        public FishingSession? GetSessionById(int id)
        {
            return _context.FishingSessions.FirstOrDefault(s => s.Id == id);    
        }
    }
}
