using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Models
{
    public class SessionModel
    {
        public int Id { get; set; }

        public int DonorId { get; set; }

        public int DonorCenterId { get; set; }

        public string DonorCenterName { get; set; }

        public int BloodVolume { get; set; }

        public DateTime Date { get; set; }

        public int StateId { get; set; }

        public string StateName { get; set; }
    }
}
