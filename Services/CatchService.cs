using FishingSessionsAPI.Data;
using FishingSessionsAPI.Interfaces;
using FishingSessionsAPI.Models;

namespace FishingSessionsAPI.Services
{
    public class CatchService : ICatchService
    {
        private readonly FishingDbContext _context;

        public CatchService(FishingDbContext context)
        {
            _context = context;
        }
        public Catch LogCatch(int fishingSessionId, DateTime caughtAt)
        {
            var catchRecord = new Catch
            {
                FishingSessionId = fishingSessionId,
                CaughtAt = caughtAt
            };

            _context.Catches.Add(catchRecord);
            _context.SaveChanges();

            return catchRecord;
        }
    }
}
