using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodFlow.DataLayer.Entities;

namespace BloodFlow.DataLayer.Interfaces.RepositoryInterfaces
{
    public interface IDonorCenterRepository : IRepository<DonorCenter>
    {
        Task<DonorCenter?> GetByIdWithDetailsAsync(int donorCenterId);

        Task<IEnumerable<DonorCenter?>> GetAllWithDetailsAsync();
    }
}
