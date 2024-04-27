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
        Task<IEnumerable<DonorModel>> GetDonorsByOrderIdAsync(int orderId);
    }
}
