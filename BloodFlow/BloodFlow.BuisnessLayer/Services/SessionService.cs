using AutoMapper;
using BloodFlow.BuisnessLayer.Interfaces;
using BloodFlow.BuisnessLayer.Models;
using BloodFlow.DataLayer.Interfaces.RepositoryInterfaces;
using BloodFlow.DataLayer.Entities;
using BloodFlow.DataLayer.Interfaces;
using BloodFlow.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Services
{
    public class SessionService : ISessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISessionRepository _sessionRepository;

        public SessionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sessionRepository = _unitOfWork.SessionRepository;
        }

        public async Task AddAsync(SessionModel model)
        {
            var sessionEntity = _mapper.Map<Session>(model);

            await _unitOfWork.SessionRepository.AddAsync(sessionEntity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int sessionId)
        {
            await _sessionRepository.DeleteByIdAsync(sessionId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<SessionModel>> GetAllAsync()
        {
            var sessionEntities = await _sessionRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<SessionModel>>(sessionEntities);
        }

        public async Task<SessionModel> GetByIdAsync(int sessionId)
        {
            var sessionEntity = await _sessionRepository.GetByIdAsync(sessionId);

            return _mapper.Map<SessionModel>(sessionEntity);
        }

        public async Task<IEnumerable<SessionModel>> GetSessionByDonorIdAsync(int donorId)
        {
            var sessionEntities = await _sessionRepository.GetByDonorIdAsync(donorId);

            return _mapper.Map<IEnumerable<SessionModel>>(sessionEntities);
        }

        public async Task UpdateAsync(SessionModel model)
        {
            var sessionEntity = _mapper.Map<Session>(model);

            _sessionRepository.Update(sessionEntity);
            await _unitOfWork.SaveAsync();
        }

    }
}
