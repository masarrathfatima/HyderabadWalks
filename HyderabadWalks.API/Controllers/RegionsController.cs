using HyderabadWalks.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HyderabadWalks.API.Models.ViewModel;
using HyderabadWalks.API.Models.Domain;
using HyderabadWalks.API.Repositories;

namespace HyderabadWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly HydWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;

        public RegionsController(HydWalksDbContext dbContext, IRegionRepository regionRepository)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await regionRepository.GetAllAsync();
            var result = regions.Select(x => new RegionViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                RegionImageUrl = x.RegionImageUrl,
            }).ToList();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetbyId([FromRoute]Guid id)
        {
            var regionsViewModel = new List<RegionViewModel>();
            var regions = dbContext.Regions.Where(x => x.Id == id).Select(x => new RegionViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                RegionImageUrl = x.RegionImageUrl,
            }).ToList();
            if (regions is not null)
                return Ok(regions);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody]RegionViewModel newRegion)
        {
            var addRegion = new Region
            {
                Code = newRegion.Code,
                Name = newRegion.Code,
                RegionImageUrl = newRegion.RegionImageUrl
            };

            dbContext.Regions.Add(addRegion);
            dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetbyId), addRegion);
        }

    }
}
