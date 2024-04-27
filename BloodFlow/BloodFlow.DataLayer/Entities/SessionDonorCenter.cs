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
        public new int Id { get; set; }

        [Column("session_id")]
        [ForeignKey(nameof(Session))]
        public int SessionId { get; set; }

        [Column("donor_center_id")]
        [ForeignKey(nameof(DonorCenter))]
        public int DonorCenterId { get; set; }

        public Session Session { get; set; } = null!;

        public DonorCenter DonorCenter { get; set; } = null!;

        public SessionDonorCenter() : base(0) { }

        public SessionDonorCenter(int id,
                                  int sessionId,
                                  int donorCenterId) : base (id)
        {
            SessionId = sessionId;
            DonorCenterId = donorCenterId;
        }
    }
}
