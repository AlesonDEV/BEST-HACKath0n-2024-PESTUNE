using BloodFlow.BuisnessLayer.Interfaces;
using BloodFlow.BuisnessLayer.Models;
using BloodFlow.BuisnessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloodFlow.PresentaionLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET: api/cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonorModel>>> Get()
        {
            IEnumerable<CityModel> cityModels = await _cityService.GetAllAsync();

            if (cityModels == null)
            {
                return NotFound();
            }

            return Ok(cityModels);
        }

        // GET: api/cities/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<DonorModel>>> GetById(int id)
        {
            CityModel cityModel = await _cityService.GetByIdAsync(id);

            if (cityModel == null)
            {
                return NotFound();
            }

            return Ok(cityModel);
        }

        // GET: api/cities/1/streets
        [HttpGet("{id}/streets")]
        public async Task<ActionResult<IEnumerable<DonorModel>>> GetStreetsByCityId(int id)
        {
            IEnumerable<StreetModel> streetModels = await _cityService.GetStreetsByCityIdAsync(id);

            if (streetModels == null)
            {
                return NotFound();
            }

            return Ok(streetModels);
        }
    }
}
