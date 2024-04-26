using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Models
{
    public class OrderModel
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int BloodVolume { get; set; }

        public long ImportanceId { get; set; }

        public string ImportanceName { get; set; }

        public long DonorCenterId { get; set; }
        
        public string DonorCenterName { get; set; }

        public ICollection<int> DonorIds { get; set; }
    }
}
