using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Models
{
    public class AddressModel
    {
        public long CityId { get; set; }

        public string CityName { get; set; }

        public long StreetId { get; set; }

        public string StreetName { get; set; }

        public int HouseNumber { get; set; }
    }
}
