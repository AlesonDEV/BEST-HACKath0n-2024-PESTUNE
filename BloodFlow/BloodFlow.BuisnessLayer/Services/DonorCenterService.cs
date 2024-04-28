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
using BloodFlow.DataLayer.Repositories;

namespace BloodFlow.BuisnessLayer.Services
{
    public class DonorCenterService : IDonorCenterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDonorCenterRepository _donorCenterRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IStreetRepository _streetRepository;
        private readonly IMapper _mapper;

        public DonorCenterService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _donorCenterRepository = _unitOfWork.DonorCenterRepository;
            _contactRepository = _unitOfWork.ContactRepository;
        }

        public async Task AddAddressByDonorCenterIdAsync(int donorCenterId, AddressModel addressModel)
        {
            BaseValidation.IsObjectNull(addressModel, nameof(addressModel));
            await AddressValidation.ValidateAddress(addressModel);

            var addressEntity = _mapper.Map<Street>(addressModel);
            BaseValidation.IsObjectNull(addressEntity, nameof(addressEntity));

            var donorCenterEntity = await _donorCenterRepository.GetByIdWithDetailsAsync(donorCenterId);
            BaseValidation.IsObjectNull(donorCenterEntity, nameof(donorCenterEntity));

            donorCenterEntity.StreetId = addressModel.StreetId;
            donorCenterEntity.HouseNumber = addressModel.HouseNumber;

            addressModel.CityId = addressEntity.CityId;

            _donorCenterRepository.Update(donorCenterEntity);
            await _unitOfWork.SaveAsync();
        }

        public async Task AddAsync(DonorCenterModel model)
        {
            BaseValidation.IsObjectNull(model, nameof(model));
            BaseValidation.IsWhiteSpaceOrNullOrEmpty(model.DonorCenterName);

            var donorCenterEntity = _mapper.Map<DonorCenter>(model);

            await _donorCenterRepository.AddAsync(donorCenterEntity);
            model.DonorCenterId = donorCenterEntity.Id;
            await _unitOfWork.SaveAsync();
        }

        public async Task AddContactByDonorCenterIdAsync(int donorCenterId, ContactModel contactModel)
        {
            BaseValidation.IsObjectNull(contactModel, nameof(contactModel));
            ContactValidation.ValidateEmail(contactModel.ContactValue);

            var contactEntity = _mapper.Map<Contact>(contactModel);
            BaseValidation.IsObjectNull(contactEntity, nameof(contactEntity));

            var donorCenterEntity = await _donorCenterRepository.GetByIdWithDetailsAsync(donorCenterId);
            BaseValidation.IsObjectNull(donorCenterEntity, nameof(donorCenterEntity));

            donorCenterEntity.Contact = contactEntity;

            await _contactRepository.AddAsync(contactEntity);
            contactModel.ContactId = contactEntity.Id;
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
            await _donorCenterRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<AddressModel> GetAddressModelByDonorCenterIdAsync(int donorCenterId)
        {
            var donorCenterEntity = await _donorCenterRepository.GetByIdWithDetailsAsync(donorCenterId);
            BaseValidation.IsObjectNull(donorCenterEntity, nameof(donorCenterEntity));

            var streetEntity = await _streetRepository.GetByIdWithDetailsAsync(donorCenterEntity.StreetId ?? 0);
            BaseValidation.IsObjectNull(streetEntity, nameof(streetEntity));

            return _mapper.Map<AddressModel>(streetEntity);
        }

        public async Task<IEnumerable<DonorCenterModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<DonorCenterModel>>
                (await _donorCenterRepository.GetAllWithDetailsAsync());
        }

        public async Task<DonorCenterModel> GetByIdAsync(int id)
        {
            var donorCenterEntity = await _donorCenterRepository.GetByIdWithDetailsAsync(id);
            BaseValidation.IsObjectNull(donorCenterEntity, nameof(donorCenterEntity));
            return _mapper.Map<DonorCenterModel>(donorCenterEntity);
        }

        public async Task<ContactModel> GetContactByDonorCenterIdAsync(int donorCenterId)
        {
            var donorCenterEntity = await _donorCenterRepository.GetByIdWithDetailsAsync(donorCenterId);
            BaseValidation.IsObjectNull(donorCenterEntity, nameof(donorCenterEntity));

            var contactEntity = (await _donorCenterRepository.GetAllAsync())
                .FirstOrDefault(contact => contact.Id == donorCenterEntity.ContactId);

            BaseValidation.IsObjectNull(contactEntity, nameof(contactEntity));

            return _mapper.Map<ContactModel>(contactEntity);
        }

        public async Task UpdateAsync(DonorCenterModel model)
        {
            var donorCenterEntity = _mapper.Map<DonorCenter>(model);

            _donorCenterRepository.Update(donorCenterEntity);
            await _unitOfWork.SaveAsync(); throw new NotImplementedException();
        }
    }
}
