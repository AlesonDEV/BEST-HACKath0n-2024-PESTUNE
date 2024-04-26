using BloodFlow.DataLayer.Interfaces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IBloodTypeRepository BloodTypeRepository { get; }

        ICityRepository CityRepository { get; }

        IDonorCenterContactRepository DonorCenterContactRepository { get; }

        IDonorCenterRepository DonorCenterRepository { get; }

        IDonorRepository DonorRepository { get; }

        IOrderRepository OrderRepository { get; }

        IPersonContactRepository PersonContactRepository { get; }

        IPersonRepository PersonRepository { get; }

        ISessionRepository SessionRepository { get; }

        IStateSessionRepository StateSessionRepository { get; }

        IStreetRepository StreetRepository { get; }

        Task SaveAsync();
    }
}
