using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodFlow.DataLayer.Entities;

namespace BloodFlow.DataLayer.Interfaces.RepositoryInterfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order?> GetByIdWithDetailsAsync(int orderId);

        Task<IEnumerable<Order>> GetAllWithDetailsAsync();
    }
}
