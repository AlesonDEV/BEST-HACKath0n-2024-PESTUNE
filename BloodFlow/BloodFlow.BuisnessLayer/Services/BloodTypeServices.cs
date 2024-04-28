using AutoMapper;
using BloodFlow.BuisnessLayer.Interfaces;
using BloodFlow.DataLayer.Entities;
using BloodFlow.DataLayer.Interfaces.RepositoryInterfaces;
using BloodFlow.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodFlow.BuisnessLayer.Validation;
using BloodFlow.DataLayer.Repositories;
using BloodFlow.BuisnessLayer.Models;

namespace BloodFlow.BuisnessLayer.Services
{
    public class BloodTypeServices : IBloodTypeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBloodTypeRepository _bloodTypeRepository;
        private readonly IMapper _mapper;

        public BloodTypeServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bloodTypeRepository = _unitOfWork.BloodTypeRepository;
        }

        public async Task AddAsync(BloodTypeModel model)
        {
            BaseValidation.IsObjectNull(model, nameof(model));
            BaseValidation.IsWhiteSpaceOrNullOrEmpty(model.BloodTypeName);

            var cityEntity = _mapper.Map<BloodType>(model);

            await _bloodTypeRepository.AddAsync(cityEntity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
            await _bloodTypeRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<BloodTypeModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<BloodTypeModel>>
                (await _bloodTypeRepository.GetAllAsync());
        }

        public async Task<BloodTypeModel> GetByIdAsync(int id)
        {
            return _mapper.Map<BloodTypeModel>
                (await _bloodTypeRepository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(BloodTypeModel model)
        {
            var bloodTypeEntity = _mapper.Map<BloodType>(model);

            _bloodTypeRepository.Update(bloodTypeEntity);
            await _unitOfWork.SaveAsync();
        }
    }
}
