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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sessions = await _sessionService.GetAllAsync();

            if (sessions == null || !sessions.Any())
            {
                return NotFound();
            }

            return Ok(sessions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var session = await _sessionService.GetByIdAsync(id);

            if (session == null)
            {
                return NotFound();
            }

            return Ok(session);
        }

        [HttpGet("donor/{donorId}")]
        public async Task<IActionResult> GetByDonorId(int donorId)
        {
            var sessions = await _sessionService.GetSessionByDonorIdAsync(donorId);

            if (sessions == null || !sessions.Any())
            {
                return NotFound();
            }

            return Ok(sessions);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SessionModel model)
        {
            await _sessionService.AddAsync(model);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(SessionModel model)
        {
            await _sessionService.UpdateAsync(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sessionService.DeleteAsync(id);

            return Ok();
        }
    }
}