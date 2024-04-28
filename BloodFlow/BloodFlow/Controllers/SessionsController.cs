using BloodFlow.BuisnessLayer.Interfaces;
using BloodFlow.BuisnessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BloodFlow.PresentaionLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionsController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        // GET: api/sessions/states
        [HttpGet("states")]
        public async Task<ActionResult<IEnumerable<StateModel>>> GetAllStates()
        {
            var statesModels = await _sessionService.GetAllStates();

            if (statesModels == null || !statesModels.Any())
            {
                return NotFound();
            }

            return Ok(statesModels);
        }

        // GET: api/sessions/1
        [HttpGet("{id}")]
        public async Task<ActionResult<SessionModel>> GetById(int id)
        {
            var session = await _sessionService.GetByIdAsync(id);

            if (session == null)
            {
                return NotFound();
            }

            return Ok(session);
        }

        // GET: api/sessions/donors/1
        [HttpGet("donors/{id}")]
        public async Task<ActionResult<IEnumerable<SessionModel>>> GetByDonorId(int id)
        {
            var sessions = await _sessionService.GetSessionsByDonorIdAsync(id);

            if (sessions == null || !sessions.Any())
            {
                return NotFound();
            }

            return Ok(sessions);
        }

        // POST: api/sessions
        [HttpPost]
        public async Task<ActionResult> Add(SessionModel model)
        {
            await _sessionService.AddAsync(model);

            return Ok();
        }
    }
}