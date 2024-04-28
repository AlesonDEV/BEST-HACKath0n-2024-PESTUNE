using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Models
{
    public class LoginResponseModel : LoginModel
    {
        public int UserId { get; set; }

        public string Role { get; set; }
    }
}
