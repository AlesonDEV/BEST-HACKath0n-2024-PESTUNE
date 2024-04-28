using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodFlow.DataLayer.Entities;

namespace BloodFlow.DataLayer.Interfaces.RepositoryInterfaces
{
    public interface ISessionRepository : IRepository<Session>
    {
        Task<Session?> GetByIdWithDetailsAsync(int sessionId);

        Task<IEnumerable<Session>> GetAllWithDetailsAsync();
    }
}
