using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Models
{
    public class SessionModel
    {
        public long Id { get; set; }

        public string DonorCenterName { get; set; }

        public int BloodVolume { get; set; }

        public DateTime Date { get; set; }

        public long StateId { get; set; }

        public string StateName { get; set; }
    }
}
