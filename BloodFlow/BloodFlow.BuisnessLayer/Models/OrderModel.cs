using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int BloodVolume { get; set; }

        public int BloodTypeId { get; set; }

        public int BloodTypeName { get; set; }

        public int ImportanceId { get; set; }

        public string ImportanceName { get; set; }

        public int DonorCenterId { get; set; }
        
        public string DonorCenterName { get; set; }
    }
}
