using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Models
{
    public class AddressModel
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

        public int StreetId { get; set; }

        public string StreetName { get; set; }

        public string? HouseNumber { get; set; }
    }
}
