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

namespace BloodFlow.BuisnessLayer.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDonorRepository _donorRepository;
        private readonly IDonorCenterRepository _donorCenterRepository;
        private readonly IMapper _mapper;

        public LoginService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _donorRepository = _unitOfWork.DonorRepository;
            _donorCenterRepository = _unitOfWork.DonorCenterRepository;
        }

        public async Task<LoginResponseModel> LoginAsync(LoginModel loginModel)
        {
            var donorId = (await LoginDonor(loginModel));
            var donorCenterId = await LoginDonorCenter(loginModel);
            LoginResponseModel loginResponseModel = null;
            if (donorId > 0)
            {
                loginResponseModel = new LoginResponseModel()
                {
                    EmailValue = loginModel.EmailValue,
                    PasswordBValue = loginModel.PasswordBValue,
                    Role = "Donor",
                    UserId = donorId,
                };
            }
            else if (donorCenterId > 0)
            {
                loginResponseModel = new LoginResponseModel()
                {
                    EmailValue = loginModel.EmailValue,
                    PasswordBValue = loginModel.PasswordBValue,
                    Role = "DonorCenter",
                    UserId = donorCenterId,
                };
            }

            return loginResponseModel;
        }

        public async Task<int> LoginDonor(LoginModel loginModel)
        {
            var isLogin = (await _donorRepository.GetAllWithDetailsAsync())
                 .Where(x => x.Person.Contact.Name == loginModel.EmailValue)
                 .FirstOrDefault();

            if (isLogin != null)
            {
                return isLogin.Id;
            }

            return -1;
        }

        public async Task<int> LoginDonorCenter(LoginModel loginModel)
        {
            var isLogin = (await _donorCenterRepository.GetAllWithDetailsAsync())
                 .Where(x => x.Contact.Name == loginModel.EmailValue)
                 .FirstOrDefault();

            if (isLogin != null)
            {
                return isLogin.Id;
            }

            return -1;
        }
    }
}
