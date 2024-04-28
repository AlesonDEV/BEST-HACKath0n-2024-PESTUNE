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

        IDonorCenterRepository DonorCenterRepository { get; }

        IDonorRepository DonorRepository { get; }

        IOrderRepository OrderRepository { get; }

        IPersonRepository PersonRepository { get; }

        ISessionRepository SessionRepository { get; }

        IStateSessionRepository StateSessionRepository { get; }

        IStreetRepository StreetRepository { get; }

        IContactRepository ContactRepository { get; }

        Task SaveAsync();
    }
}
