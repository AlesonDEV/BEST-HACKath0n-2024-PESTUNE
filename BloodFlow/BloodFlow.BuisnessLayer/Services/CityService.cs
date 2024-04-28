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
using BloodFlow.BuisnessLayer.Models;
using BloodFlow.BuisnessLayer.Validation;
using BloodFlow.DataLayer.Repositories;

namespace BloodFlow.BuisnessLayer.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICityRepository _cityRepository;
        private readonly IStreetRepository _streetRepository;
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cityRepository = _unitOfWork.CityRepository;
            _streetRepository = _unitOfWork.StreetRepository;
        }

        public async Task AddAsync(CityModel model)
        {
            BaseValidation.IsObjectNull(model, nameof(model));
            BaseValidation.IsWhiteSpaceOrNullOrEmpty(model.CityName);

            var cityEntity = _mapper.Map<City>(model);

            await _cityRepository.AddAsync(cityEntity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
            await _cityRepository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CityModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CityModel>>
                (await _cityRepository.GetAllAsync());
        }

        public async Task<CityModel> GetByIdAsync(int id)
        {
            return _mapper.Map<CityModel>
                (await _cityRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<StreetModel>> GetStreetsByCityIdAsync(int cityId)
        {
            var streetsByCityId = (await _streetRepository.GetAllWithDetailsAsync())
                                            .Where(x => x!.CityId == cityId);

            return _mapper.Map<IEnumerable<StreetModel>>(streetsByCityId);
        }

        public async Task UpdateAsync(CityModel model)
        {
            var cityEntity = _mapper.Map<City>(model);

            _cityRepository.Update(cityEntity);
            await _unitOfWork.SaveAsync();
        }
    }
}
