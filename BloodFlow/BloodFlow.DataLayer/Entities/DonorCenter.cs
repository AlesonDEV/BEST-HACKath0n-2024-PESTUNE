using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Entities
{
    [Table("donor_center")]
    public class DonorCenter : BaseEntity
    {
        [Column("street_id")]
        [ForeignKey(nameof(Street))]
        public int StreetId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("house_number")]
        public int HouseNumber { get; set; }

        public Street Street { get; set; } = null!;

        public ICollection<Order>? Orders { get; set; }

        public ICollection<SessionDonorCenter>? SessionDonorCenters { get; set; }

        public ICollection<DonorCenterContact> DonorCenterContacts { get; set; } = null!;

        public DonorCenter() : base(0) { }

        public DonorCenter(int id,
            int streetId, 
            string name, 
            int houseNumber) : base(id)
        {
            StreetId = streetId;
            Name = name;
            HouseNumber = houseNumber;
        }
    }
}
