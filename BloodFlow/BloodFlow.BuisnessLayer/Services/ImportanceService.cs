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
    public class ImportanceService : IImportanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImportanceRepository _importanceRepository;
        private readonly IMapper _mapper;

        public ImportanceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _importanceRepository = _unitOfWork.ImportanceRepository;
        }

        public async Task AddAsync(ImportanceModel model)
        {
            BaseValidation.IsObjectNull(model, nameof(model));
            BaseValidation.IsWhiteSpaceOrNullOrEmpty(model.ImportanceName);

            var importanceEntity = _mapper.Map<Importance>(model);

            await _importanceRepository.AddAsync(importanceEntity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
            await _importanceRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ImportanceModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ImportanceModel>>
                (await _importanceRepository.GetAllAsync());
        }

        public async Task<ImportanceModel> GetByIdAsync(int id)
        {
            return _mapper.Map<ImportanceModel>
                (await _importanceRepository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(ImportanceModel model)
        {
            var importanceEntity = _mapper.Map<Importance>(model);

            _importanceRepository.Update(importanceEntity);
            await _unitOfWork.SaveAsync();
        }
    }
}
