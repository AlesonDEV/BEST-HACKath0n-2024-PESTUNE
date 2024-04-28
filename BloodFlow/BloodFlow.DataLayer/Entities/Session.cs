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
        public int DonorCenterId { get; set; }

        [Column("blood_type_id")]
        public int BloodTypeId { get; set; }

        [Column("blood_volume")]
        public int BloodVolume { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("state_id")]
        [ForeignKey(nameof(StateSession))]
        public int StateId { get; set; }

        public StateSession StateSession { get; set; }

        public ICollection<DonorSession>? DonorSessions { get; set; } 

        public ICollection<SessionDonorCenter>? SessionDonorCenters { get; set; }

        public Session(int id,
            int donorCenterId,
            int bloodTypeId,
            int bloodVolume,
            DateTime date,
            int stateId) : base(id)
        {
            DonorCenterId = donorCenterId;
            BloodTypeId = bloodTypeId;
            BloodVolume = bloodVolume;
            Date = date;
            StateId = stateId;
        }
    }
}
