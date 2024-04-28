using BloodFlow.BuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResponseModel> LoginAsync(LoginModel loginModel);

        Task<int> LoginDonor(LoginModel loginModel);

        Task<int> LoginDonorCenter(LoginModel loginModel);
    }
}
