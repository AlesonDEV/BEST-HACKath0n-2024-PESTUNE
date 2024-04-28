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
        [ForeignKey(nameof(DonorCenter))]
        public int DonorCenterId { get; set; }

        [Column("blood_volume")]
        public int BloodVolume { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("state_id")]
        [ForeignKey(nameof(State))]
        public int StateId { get; set; }

        [Column("donor_id")]
        [ForeignKey(nameof(Donor))]
        public int DonorId { get; set; }

        public State State { get; set; }

        public DonorCenter DonorCenter { get; set; }

        public Donor Donor { get; set; }

        public Session() : base(0) { }
        public Session(int id,
            int donorCenterId,
            int bloodVolume,
            DateTime date,
            int stateId,
            int donorId) : base(id)
        {
            DonorCenterId = donorCenterId;
            BloodVolume = bloodVolume;
            Date = date;
            StateId = stateId;
            DonorId = donorId;
        }
    }
}
