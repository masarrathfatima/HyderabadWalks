using HyderabadWalks.API.Models.ViewModel;
using HyderabadWalks.API.Data;
using Microsoft.EntityFrameworkCore;
using HyderabadWalks.API.Models.Domain;


namespace HyderabadWalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly HydWalksDbContext dbContext;

        public SQLRegionRepository(HydWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }
    }
}
