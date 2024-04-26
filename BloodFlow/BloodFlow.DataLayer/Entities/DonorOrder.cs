using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Entities
{
    [Table("donor_order")]
    public class DonorOrder : BaseEntity
    {
        // Overhiding the name of the variable from base entity and
        // set not mapped to not create this column in the database
        [NotMapped]
        public new long Id { get; set; }

        [Column("donor_id")]
        [ForeignKey(nameof(Donor))]
        public long DonorId { get; set; }

        [Column("order_id")]
        [ForeignKey(nameof(Order))]
        public long OrderId { get; set; }

        public Donor Donor { get; set; } = null!;

        public Order Order { get; set; } = null!;

        public DonorOrder() : base(0) { }

        public DonorOrder(long id,
            long donorId,
            long orderId) : base(id)
        {
            DonorId = donorId;
            OrderId = orderId;
        }
    }
}
