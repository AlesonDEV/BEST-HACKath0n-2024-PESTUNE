using BloodFlow.BuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Interfaces
{
    public interface IDonorService : ICrud<DonorModel>
    {
        Task<IEnumerable<DonorModel>> GetDonorsByOrderIdAsync(int donorId);

        Task<ContactModel> GetContactByDonorIdAsync(int donorId);

        Task AddContactByDonorIdAsync(int donorId, ContactModel contactModel);

        Task<AddressModel> GetAddressModelByDonorIdAsync(int donorId);

        Task AddAddressByDonorIdAsync(int donorId, AddressModel addressModel);
    }
}
