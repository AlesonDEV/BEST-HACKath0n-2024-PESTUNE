using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Models
{
    public class AddressWithCoordinatesModel : AddressModel
    {
        public string LatValue { get; set; }

        public string LngValue { get; set; }
    }
}
