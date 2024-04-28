using BloodFlow.BuisnessLayer.Interfaces;
using BloodFlow.BuisnessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BloodFlow.PresentaionLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/orders/1
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderModel>> GetById(int id)
        {
            OrderModel orderModel = await _orderService.GetByIdAsync(id);

            if (orderModel == null)
            {
                return NotFound();
            }

            return Ok(orderModel);
        }

        // POST: api/orders
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] OrderModel orderModel)
        {
            await _orderService.AddAsync(orderModel);

            return Created($"/api/orders/{orderModel.Id}", orderModel);
        }

        // PUT: api/orders/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] OrderModel orderModel)
        {
            orderModel.Id = id;
            await _orderService.UpdateAsync(orderModel);

            return NoContent();
        }

        // DELETE: api/orders/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _orderService.DeleteAsync(id);

            return NoContent();
        }

        // GET: api/orders?BloodTypeId=1&ImportanceId=2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetOrdersByFilter(
            [FromQuery] FilterSearchModel filterSearchModel)
        {
            var orderModels = await _orderService.GetByFilterAsync(filterSearchModel);

            if (orderModels == null)
            {
                return NotFound();
            }

            return Ok(orderModels);
        }

        // PUT: api/orders/{id}/donors/add/{donorId}
        [HttpPut("{id}/donors/add/{donorId}")]
        public async Task<ActionResult> UpdateDonors(int id, int donorId, int bloodVolume)
        {
            await _orderService.AddDonorAsync(donorId, id, bloodVolume);

            return NoContent();
        }

        // PUT: api/orders/{id}/donors/remove/{donorId}
        [HttpPut("{id}/donors/remove/{donorId}")]
        public async Task<ActionResult> RemoveDonor(int id, int donorId)
        {
            await _orderService.RemoveDonorAsync(donorId, id);

            return NoContent();
        }
    }
}
