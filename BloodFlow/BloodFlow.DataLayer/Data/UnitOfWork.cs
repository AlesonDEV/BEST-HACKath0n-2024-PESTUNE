using BloodFlow.DataLayer.Interfaces;
using BloodFlow.DataLayer.Interfaces.RepositoryInterfaces;
using BloodFlow.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BloodFlowDbContext _context;
        private IBloodTypeRepository _bloodTypeRepository;
        private ICityRepository _cityRepository;
        private IDonorCenterRepository _donorCenterRepository;
        private IDonorRepository _donorRepository;
        private IOrderRepository _orderRepository;
        private IPersonRepository _personRepository;
        private ISessionRepository _sessionRepository;
        private IStateSessionRepository _stateSessionRepository;
        private IStreetRepository _streetRepository;
        private IContactRepository _contactRepository;

        public UnitOfWork(BloodFlowDbContext context)
        {
            _context = context;
        }

        public IContactRepository ContactRepository
        {
            get
            {
                this._contactRepository ??= new ContactRepository(_context);
                return this._contactRepository;
            }
        }

        public IBloodTypeRepository BloodTypeRepository
        {
            get
            {
                this._bloodTypeRepository ??= new BloodTypeRepository(_context);
                return this._bloodTypeRepository;
            }
        }

        public ICityRepository CityRepository
        {
            get
            {
                this._cityRepository ??= new CityRepository(_context);
                return this._cityRepository;
            }
        }

        public IDonorCenterRepository DonorCenterRepository
        {
            get
            {
                this._donorCenterRepository ??= new DonorCenterRepository(_context);
                return this._donorCenterRepository;
            }
        }

        public IDonorRepository DonorRepository
        {
            get
            {
                this._donorRepository ??= new DonorRepository(_context);
                return this._donorRepository;
            }
        }


        public IOrderRepository OrderRepository
        {
            get
            {
                this._orderRepository ??= new OrderRepository(_context);
                return this._orderRepository;
            }
        }

        public IPersonRepository PersonRepository
        {
            get
            {
                this._personRepository ??= new PersonRepository(_context);
                return this._personRepository;
            }
        }

        public ISessionRepository SessionRepository
        {
            get
            {
                this._sessionRepository ??= new SessionRepository(_context);
                return this._sessionRepository;
            }
        }

        public IStateSessionRepository StateSessionRepository
        {
            get
            {
                this._stateSessionRepository ??= new StateSessionRepository(_context);
                return this._stateSessionRepository;
            }
        }

        public IStreetRepository StreetRepository
        {
            get
            {
                this._streetRepository ??= new StreetRepository(_context);
                return this._streetRepository;
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
