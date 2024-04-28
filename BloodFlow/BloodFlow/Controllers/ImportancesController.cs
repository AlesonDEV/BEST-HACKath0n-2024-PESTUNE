using BloodFlow.BuisnessLayer.Interfaces;
using BloodFlow.BuisnessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BloodFlow.PresentaionLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportancesController : ControllerBase
    {
        private readonly IImportanceService _importanceService;

        public ImportancesController(IImportanceService importanceService)
        {
            _importanceService = importanceService;
        }

        // GET: api/importances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImportanceModel>>> Get()
        {
            IEnumerable<ImportanceModel> bloodTypeModels = await _importanceService.GetAllAsync();

            if (bloodTypeModels == null)
            {
                return NotFound();
            }

            return Ok(bloodTypeModels);
        }
    }
}
