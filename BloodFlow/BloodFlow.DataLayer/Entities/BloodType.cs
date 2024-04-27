using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Entities
{
    [Table("blood_type")]
    public class BloodType : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        public ICollection<Donor>? Donors { get; set; }

        public BloodType() : base(0) { }

        public BloodType(int id,
            string name) : base(id)
        {
            Name = name;
        }
    }
}
