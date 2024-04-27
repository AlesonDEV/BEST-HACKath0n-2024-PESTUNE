using BloodFlow.BuisnessLayer.Interfaces;
using BloodFlow.BuisnessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BloodFlow.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllAsync();

            if (orders == null || !orders.Any())
            {
                return NotFound();
            }

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Add(OrderModel model)
        {
            await _orderService.AddAsync(model);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(OrderModel model)
        {
            await _orderService.UpdateAsync(model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.DeleteAsync(id);

            return Ok();
        }

        [HttpPost("{orderId}/donors/{donorId}")]
        public async Task<IActionResult> AddDonor(int donorId, int orderId, int bloodVolume)
        {
            await _orderService.AddDonorAsync(donorId, orderId, bloodVolume);

            return Ok();
        }

        [HttpDelete("{orderId}/donors/{donorId}")]
        public async Task<IActionResult> RemoveDonor(int donorId, int orderId)
        {
            await _orderService.RemoveDonorAsync(donorId, orderId);

            return Ok();
        }
    }
}