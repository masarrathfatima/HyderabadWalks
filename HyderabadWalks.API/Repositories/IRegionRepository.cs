using HyderabadWalks.API.Models.Domain;
using HyderabadWalks.API.Models.ViewModel;

namespace HyderabadWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
    }
}
