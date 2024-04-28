using BloodFlow.BuisnessLayer.Models;
using BloodFlow.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Interfaces
{
    public interface ISessionService : ICrud<SessionModel>
    {
        Task<IEnumerable<SessionModel>> GetSessionsByDonorIdAsync(int donorId);

        Task<IEnumerable<StateModel>> GetAllStates();
    }
}
