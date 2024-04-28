using BloodFlow.BuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Interfaces
{
    public interface IOrderService : ICrud<OrderModel>
    {
        Task AddDonorAsync(int donorId, int orderId, int bloodVolume);

        Task RemoveDonorAsync(int donorId, int orderId);

        Task<IEnumerable<OrderModel>> GetByFilterAsync(FilterSearchModel filterSearch);
    }
}
