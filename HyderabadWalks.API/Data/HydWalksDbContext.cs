using HyderabadWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HyderabadWalks.API.Data
{
    public class HydWalksDbContext : DbContext
    {
        public HydWalksDbContext(DbContextOptions dbContextOptions) : base (dbContextOptions)
        {
                
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}
