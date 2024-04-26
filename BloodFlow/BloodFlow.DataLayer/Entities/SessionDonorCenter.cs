using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Entities
{
    [Table("session_donor_center")]
    public class SessionDonorCenter : BaseEntity
    {
        // Overhiding the name of the variable from base entity and
        // set not mapped to not create this column in the database
        [NotMapped]
        public new long Id { get; set; }

        [Column("session_id")]
        [ForeignKey(nameof(Session))]
        public long SessionId { get; set; }

        [Column("donor_center_id")]
        [ForeignKey(nameof(DonorCenter))]
        public long DonorCenterId { get; set; }

        public Session Session { get; set; } = null!;

        public DonorCenter DonorCenter { get; set; } = null!;

        public SessionDonorCenter() : base(0) { }

        public SessionDonorCenter(long id,
            long sessionId,
            long donorCenterId) : base (id)
        {
            SessionId = sessionId;
            DonorCenterId = donorCenterId;
        }
    }
}
