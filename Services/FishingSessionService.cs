using FishingSessionsAPI.Data;
using FishingSessionsAPI.Interfaces;
using FishingSessionsAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using FishingSessionsAPI.Results;
using FishingSessionsAPI.Enums;

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

        public EndSessionResult EndSession(int id)
        {
            var session = GetSessionById(id);

            if (session == null)
            {
                return new EndSessionResult
                {
                    OutCome = EndSessionOutcome.NotFound,
                    ErrorMessage = "Fishing session not found"
                };
            }

            if (session.EndTime != null)
            {
                return new EndSessionResult
                {
                    OutCome = EndSessionOutcome.AlreadyEnded,
                    ErrorMessage = "Fishing session has already been ended"
                };
            }

            session.EndTime = DateTime.Now;

            _context.SaveChanges();

            return new EndSessionResult
            {
                OutCome = EndSessionOutcome.Success
            };
        }

        public FishingSession? GetSessionById(int id)
        {
            return _context.FishingSessions.FirstOrDefault(s => s.Id == id);
        }
    }
}
