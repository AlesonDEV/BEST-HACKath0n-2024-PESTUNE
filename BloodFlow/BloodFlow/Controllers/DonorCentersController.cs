using BloodFlow.BuisnessLayer.Interfaces;
using BloodFlow.BuisnessLayer.Models;
using BloodFlow.BuisnessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BloodFlow.PresentaionLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorCentersController : Controller
    {
        private readonly IDonorCenterService _donorCenterService;

        public DonorCentersController(IDonorCenterService DonorCenterService)
        {
            _donorCenterService = DonorCenterService;
        }

        // GET: api/donorcenters/1
        [HttpGet("{id}")]
        public async Task<ActionResult<DonorCenterModel>> GetById(int id)
        {
            DonorCenterModel donorModel = await _donorCenterService.GetByIdAsync(id);

            if (donorModel == null)
            {
                return NotFound();
            }

            return Ok(donorModel);
        }

        // GET: api/donorcenters/1/contacts
        [HttpGet("{id}/contacts")]
        public async Task<ActionResult<ContactModel>> GetContactById(int id)
        {
            ContactModel contactModel = await _donorCenterService.GetContactByDonorCenterIdAsync(id);

            if (contactModel == null)
            {
                return NotFound();
            }

            return Ok(contactModel);
        }

        // POST: api/donorcenters/1/contacts
        [HttpPost("{id}/contacts")]
        public async Task<ActionResult<ContactModel>> AddContactById(int id, [FromBody] ContactModel value)
        {
            await _donorCenterService.AddContactByDonorCenterIdAsync(id, value);

            return Created($"/api/donorcenters/{id}/contacts", value);
        }

        // GET: api/donorcenters/1/addressesx
        [HttpGet("{id}/addresses")]
        public async Task<ActionResult<DonorModel>> GetAddressById(int id)
        {
            AddressModel addressModel = await _donorCenterService.GetAddressModelByDonorCenterIdAsync(id);

            if (addressModel == null)
            {
                return NotFound();
            }

            return Ok(addressModel);
        }

        // POST: api/donorcenters/1/addresses
        [HttpPost("{id}/addresses")]
        public async Task<ActionResult<AddressModel>> AddAddressById(int id, [FromBody] AddressModel value)
        {
            await _donorCenterService.AddAddressByDonorCenterIdAsync(id, value);

            return Created($"/api/donorcenters/{id}/addresses", value);
        }

        // POST: api/donorcenters
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] DonorCenterModel donorCenterModel)
        {
            await _donorCenterService.AddAsync(donorCenterModel);

            return Created($"/api/donorcenters/{donorCenterModel}", donorCenterModel);
        }
    }
}
