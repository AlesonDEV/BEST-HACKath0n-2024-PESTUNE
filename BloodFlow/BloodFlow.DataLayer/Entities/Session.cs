using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Entities
{
    [Table("session")]
    public class Session : BaseEntity
    {
        [Column("donor_center_id")]
        public long DonorCenterId { get; set; }

        [Column("blood_type_id")]
        public long BloodTypeId { get; set; }

        [Column("blood_volume")]
        public int BloodVolume { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("state_id")]
        public long StateId { get; set; }

        public ICollection<DonorSession>? DonorSessions { get; set; } 

        public ICollection<SessionDonorCenter>? SessionDonorCenters { get; set; }

        public Session(long id,
            long donorCenterId,
            long bloodTypeId,
            int bloodVolume,
            DateTime date,
            long stateId) : base(id)
        {
            DonorCenterId = donorCenterId;
            BloodTypeId = bloodTypeId;
            BloodVolume = bloodVolume;
            Date = date;
            StateId = stateId;
        }
    }
}
