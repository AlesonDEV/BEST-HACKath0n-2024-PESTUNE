using BloodFlow.BuisnessLayer.Interfaces;
using BloodFlow.BuisnessLayer.Models;
using Microsoft.AspNetCore.Mvc;

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

        // GET: api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderModel>>> Get()
        {
            IEnumerable<OrderModel> orderModels = await _orderService.GetAllAsync();

            if (orderModels == null)
            {
                return NotFound();
            }
            
            return Ok(orderModels); 
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

        // POST: api/orders/1
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] OrderModel orderModel)
        {
            await _orderService.AddAsync(orderModel);

            return NoContent();
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
    }
}
