using AutoMapper;
using BloodFlow.BuisnessLayer.Interfaces;
using BloodFlow.BuisnessLayer.Models;
using BloodFlow.DataLayer.Interfaces.RepositoryInterfaces;
using BloodFlow.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodFlow.BuisnessLayer.Validation;
using BloodFlow.DataLayer.Entities;

namespace BloodFlow.BuisnessLayer.Services
{
    public class DonorService : IDonorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDonorRepository _donorRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IStreetRepository _streetRepository;
        private readonly IMapper _mapper;

        public DonorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _donorRepository = _unitOfWork.DonorRepository;
            _contactRepository = _unitOfWork.ContactRepository;
            _streetRepository = _unitOfWork.StreetRepository;
        }

        public async Task AddAddressByDonorIdAsync(int donorId, AddressModel addressModel)
        {
            BaseValidation.IsObjectNull(addressModel, nameof(addressModel));
            await AddressValidation.ValidateAddress(addressModel);

            var addressEntity = _mapper.Map<Street>(addressModel);
            BaseValidation.IsObjectNull(addressEntity, nameof(addressEntity));

            var donorEntity = await _donorRepository.GetByIdWithDetailsAsync(donorId);
            BaseValidation.IsObjectNull(donorEntity, nameof(donorEntity));

            donorEntity.Person.StreetId = addressModel.StreetId;
            donorEntity.Person.HouseNumber = addressModel.HouseNumber;

            _donorRepository.Update(donorEntity);
            await _unitOfWork.SaveAsync();
        }

        public async Task AddAsync(DonorModel model)
        {
            DonorValidation.ValidateDonor(model);

            var donorEntity = _mapper.Map<Donor>(model);

            await _donorRepository.AddAsync(donorEntity);
            model.Id = donorEntity.Id;
            await _unitOfWork.SaveAsync();
        }

        public async Task AddContactByDonorIdAsync(int donorId, ContactModel contactModel)
        {
            BaseValidation.IsObjectNull(contactModel, nameof(contactModel));
            ContactValidation.ValidateEmail(contactModel.ContactValue);

            var contactEntity = _mapper.Map<Contact>(contactModel);
            BaseValidation.IsObjectNull(contactEntity, nameof(contactEntity));

            var donorEntity = await _donorRepository.GetByIdWithDetailsAsync(donorId);
            BaseValidation.IsObjectNull(donorEntity, nameof(donorEntity));

            donorEntity.Person.Contact = contactEntity;

            await _contactRepository.AddAsync(contactEntity);
            contactModel.ContactId = contactEntity.Id;
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
            await _donorRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<AddressModel> GetAddressModelByDonorIdAsync(int donorId)
        {
            var donorEntity = await _donorRepository.GetByIdWithDetailsAsync(donorId);
            BaseValidation.IsObjectNull(donorEntity, nameof(donorEntity));

            var streetEntity = await _streetRepository.GetByIdWithDetailsAsync(donorEntity.Person.StreetId ?? 0);
            BaseValidation.IsObjectNull(streetEntity, nameof(streetEntity));

            return _mapper.Map<AddressModel>(streetEntity);
        }

        public async Task<IEnumerable<DonorModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<DonorModel>>
                (await _donorRepository.GetAllWithDetailsAsync());
        }

        public async Task<DonorModel> GetByIdAsync(int id)
        {
            var donorEntity = await _donorRepository.GetByIdWithDetailsAsync(id);
            BaseValidation.IsObjectNull(donorEntity, nameof(donorEntity));
            return _mapper.Map<DonorModel>(donorEntity);
        }

        public async Task<ContactModel> GetContactByDonorIdAsync(int donorId)
        {
            var donorEntity = await _donorRepository.GetByIdWithDetailsAsync(donorId);
            BaseValidation.IsObjectNull(donorEntity, nameof(donorEntity));

            var contactEntity = (await _contactRepository.GetAllAsync())
                .FirstOrDefault(contact => contact.Id == donorEntity.Person.ContactId);

            BaseValidation.IsObjectNull(contactEntity, nameof(contactEntity));

            return _mapper.Map<ContactModel>(contactEntity);
        }

        public async Task<IEnumerable<DonorModel>> GetDonorsByOrderIdAsync(int donorId)
        {
            var donorEntities = await _donorRepository.GetAllWithDetailsAsync();

            var donorsByOrderId = donorEntities
                .Where(c => c.DonorOrders!
                    .Any(r => r.OrderId == donorId))
                .ToList();

            return _mapper.Map<IEnumerable<DonorModel>>(donorsByOrderId);
        }

        public async Task UpdateAsync(DonorModel model)
        {
            var donorEntity = _mapper.Map<Donor>(model);

            _donorRepository.Update(donorEntity);
            await _unitOfWork.SaveAsync();
        }
    }
}
