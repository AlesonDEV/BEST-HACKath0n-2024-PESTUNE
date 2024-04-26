using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Entities
{
    [Table("donor_center_contact")]
    public class DonorCenterContact : BaseEntity
    {
        // Overhiding the name of the variable from base entity and
        // set not mapped to not create this column in the database
        [NotMapped]
        public new long Id { get; set; }

        [Column("donor_center_id")]
        [ForeignKey(nameof(DonorCenter))]
        public long DonorCenterId { get; set; }

        [Column("contact_type_id")]
        [ForeignKey(nameof(ContactType))]
        public long ContactTypeId { get; set; }

        [Column("contact_value")]
        public string ContactValue { get; set; } = null!;

        public DonorCenter DonorCenter { get; set; } = null!;

        public ContactType ContactType { get; set; } = null!;

        public DonorCenterContact() : base(0) { }

        public DonorCenterContact(long id,
            long donorCenterId,
            long contactTypeId,
            string contactValue) : base(id)
        {
            DonorCenterId = donorCenterId;
            ContactTypeId = contactTypeId;
            ContactValue = contactValue;
        }
    }
}
