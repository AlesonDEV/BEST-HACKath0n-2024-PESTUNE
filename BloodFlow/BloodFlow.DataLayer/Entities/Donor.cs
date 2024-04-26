using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Entities
{
    [Table("donor")]
    public class Donor : BaseEntity
    {
        // Overhiding the name of the variable from base entity
        [Column("person_id")]
        public new long Id { get; set; }

        [Column("blood_type_id")]
        [ForeignKey(nameof(BloodType))]
        public long BloodTypeId { get; set; }

        public BloodType BloodType { get; set; } = null!;

        public ICollection<DonorOrder>? DonorOrders { get; set; }

        public ICollection<DonorSession>? DonorSessions { get; set; }

        public Donor(long id,
            long bloodTypeId) : base(id)
        {
            BloodTypeId = bloodTypeId;
        }
    }
}
