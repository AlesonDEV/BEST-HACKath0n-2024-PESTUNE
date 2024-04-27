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
        private readonly IMapper _mapper;

        public DonorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _donorRepository = _unitOfWork.DonorRepository;
        }

        public async Task AddAsync(DonorModel model)
        {
            DonorValidation.ValidateDonor(model);

            var donorEntity = _mapper.Map<Donor>(model);

            await _donorRepository.AddAsync(donorEntity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
            await _donorRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
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

        public async Task<IEnumerable<DonorModel>> GetDonorsByOrderIdAsync(int orderId)
        {
            var donorEntities = await _donorRepository.GetAllWithDetailsAsync();

            var donorsByOrderId = donorEntities
                .Where(c => c.DonorOrders!
                    .Any(r => r.OrderId == orderId))
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
