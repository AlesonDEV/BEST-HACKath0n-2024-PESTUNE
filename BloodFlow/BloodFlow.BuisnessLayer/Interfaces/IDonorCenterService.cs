using BloodFlow.BuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Interfaces
{
    public interface IDonorCenterService : ICrud<DonorCenterModel>
    {
        Task<ContactModel> GetContactByDonorCenterIdAsync(int donorCenterId);

        Task AddContactByDonorCenterIdAsync(int donorCenterId, ContactModel contactModel);

        Task<AddressModel> GetAddressModelByDonorCenterIdAsync(int donorCenterId);

        Task AddAddressByDonorCenterIdAsync(int donorCenterId, AddressModel addressModel);
    }
}
