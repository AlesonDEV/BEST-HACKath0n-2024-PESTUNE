using BloodFlow.BuisnessLayer.Interfaces;
using BloodFlow.BuisnessLayer.Models;
using BloodFlow.BuisnessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloodFlow.PresentaionLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodTypesController : ControllerBase
    {
        private readonly IBloodTypeServices _bloodTypeService;

        public BloodTypesController(IBloodTypeServices bloodTypeService)
        {
            _bloodTypeService = bloodTypeService;
        }

        // GET: api/bloodtypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BloodTypeModel>>> Get()
        {
            IEnumerable<BloodTypeModel> bloodTypeModels = await _bloodTypeService.GetAllAsync();

            if (bloodTypeModels == null)
            {
                return NotFound();
            }

            return Ok(bloodTypeModels);
        }
    }
}
