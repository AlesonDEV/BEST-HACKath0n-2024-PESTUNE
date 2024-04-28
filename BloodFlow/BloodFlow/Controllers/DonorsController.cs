using BloodFlow.BuisnessLayer.Interfaces;
using BloodFlow.BuisnessLayer.Models;
using BloodFlow.BuisnessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloodFlow.PresentaionLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        private readonly IDonorService _donorService;

        public DonorsController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        // GET: api/donors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonorModel>>> Get()
        {
            IEnumerable<DonorModel> donorModels = await _donorService.GetAllAsync();

            if (donorModels == null)
            {
                return NotFound();
            }

            return Ok(donorModels);
        }

        // GET: api/donors/1
        [HttpGet("{id}")]
        public async Task<ActionResult<DonorModel>> GetById(int id)
        {
            DonorModel donorModel = await _donorService.GetByIdAsync(id);

            if (donorModel == null)
            {
                return NotFound();
            }

            return Ok(donorModel);
        }

        // GET: api/donors/orders/1
        [HttpGet("orders/{id}")]
        public async Task<ActionResult<IEnumerable<DonorModel>>> GetDonorsByOrderId(int id)
        {
            IEnumerable<DonorModel> donorModels = await _donorService.GetDonorsByOrderIdAsync(id);

            if (donorModels == null)
            {
                return NotFound();
            }

            return Ok(donorModels);
        }

        // POST: api/donors/1
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] DonorModel donorModel)
        {
            await _donorService.AddAsync(donorModel);

            return NoContent();
        }

        // PUT: api/donors/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] DonorModel donorModel)
        {
            donorModel.Id = id;
            await _donorService.UpdateAsync(donorModel);

            return NoContent();
        }

        // DELETE: api/donors/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _donorService.DeleteAsync(id);

            return NoContent();
        }

        // GET: api/donors/1/contacts
        [HttpGet("{id}/contacts")]
        public async Task<ActionResult<ContactModel>> GetContactById(int id)
        {
            ContactModel contactModel = await _donorService.GetContactByDonorIdAsync(id);

            if (contactModel == null)
            {
                return NotFound();
            }

            return Ok(contactModel);
        }

        // POST: api/donors/1/contacts
        [HttpPost("{id}/contacts")]
        public async Task<ActionResult<ContactModel>> AddContactById(int id, [FromBody] ContactModel value)
        {
            await _donorService.AddContactByDonorIdAsync(id, value);

            return NoContent();
        }

        // GET: api/donors/1/address
        [HttpGet("{id}/addresses")]
        public async Task<ActionResult<DonorModel>> GetAddressById(int id)
        {
            AddressModel addressModel = await _donorService.GetAddressModelByDonorIdAsync(id);

            if (addressModel == null)
            {
                return NotFound();
            }

            return Ok(addressModel);
        }

        // POST: api/donors/1/address
        [HttpPost("{id}/addresses")]
        public async Task<ActionResult<AddressModel>> AddAddressById(int id, [FromBody] AddressModel value)
        {
            await _donorService.AddAddressByDonorIdAsync(id, value);

            return NoContent();
        }
    }
}
