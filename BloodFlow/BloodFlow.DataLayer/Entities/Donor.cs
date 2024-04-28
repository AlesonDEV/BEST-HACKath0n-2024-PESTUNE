using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Entities
{
    [Table("donor")]
    public class Donor : BaseEntity
    {
        [Column("blood_type_id")]
        [ForeignKey(nameof(BloodType))]
        public int? BloodTypeId { get; set; }

        public BloodType BloodType { get; set; } = null!;

        public ICollection<DonorOrder>? DonorOrders { get; set; }

        public ICollection<Session>? Sessions { get; set; }

        public Person Person { get; set; } = null!;

        public Donor() : base(0) { }

        public Donor(int id,
            int bloodTypeId,
            string password) : base(id)
        {
            BloodTypeId = bloodTypeId;
        }
    }
}
