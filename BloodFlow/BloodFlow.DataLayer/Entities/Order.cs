﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Entities
{
    [Table("order")]
    public class Order : BaseEntity
    {
        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("blood_volume")]
        public int BloodVolume { get; set; }

        [Column("donor_center_id")]
        [ForeignKey(nameof(DonorCenter))]
        public long DonorCenterId { get; set; }

        [Column("importance_id")]
        [ForeignKey(nameof(Importance))]
        public long ImportanceId { get; set; }

        public Importance Importance { get; set; } = null!;

        public DonorCenter DonorCenter { get; set; } = null!;

        public ICollection<DonorOrder> DonorOrders { get; set; } = null!;

        public Order(long id,
            string title,
            string description,
            int bloodVolume,
            long donorCenterId,
            long importanceId) : base(id)
        {
            Title = title;
            Description = description;
            BloodVolume = bloodVolume;
            DonorCenterId = donorCenterId;
            ImportanceId = importanceId;
        }
    }
}
