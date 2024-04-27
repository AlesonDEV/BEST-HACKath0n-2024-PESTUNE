using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Entities
{
    [Table("importance")]
    public class Importance : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; } = null!;

        public Importance() : base(0) { }

        public Importance(int id,
            string name) : base(id)
        {
            Name = name;
        }
    }
}
