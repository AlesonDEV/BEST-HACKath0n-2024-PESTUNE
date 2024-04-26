using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Entities
{
    [Table("donor_session")]
    public class DonorSession : BaseEntity
    {
        // Overhiding the name of the variable from base entity and
        // set not mapped to not create this column in the database
        [NotMapped]
        public new long Id { get; set; }

        [Column("session_id")]
        [ForeignKey(nameof(Session))]
        public long SessionId { get; set; }

        [Column("donor_id")]
        [ForeignKey(nameof(Donor))]
        public long DonorId { get; set; }

        public Session Session { get; set; } = null!;
        
        public Donor Donor { get; set; } = null!; 

        public DonorSession() : base(0) { }

        public DonorSession(long id,
            long sessionId,
            long donorId) : base(id)
        {
            SessionId = sessionId;
            DonorId = donorId;
        }
    }
}
