using FishingSessionsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FishingSessionsAPI.Data
{
    public class FishingDbContext : DbContext
    {
        public FishingDbContext(DbContextOptions<FishingDbContext> options) : base(options)
        {

        }

        public DbSet<FishingSession> FishingSessions { get; set; }
        public DbSet<Catch> Catches { get; set; }
    }
}
