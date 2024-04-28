using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Models
{
    public class DonorModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirthday { get; set; }

        public string PhotoLink { get; set; }

        public int BloodTypeId { get; set; }

        public string BloodTypeName { get; set; }
    }
}
