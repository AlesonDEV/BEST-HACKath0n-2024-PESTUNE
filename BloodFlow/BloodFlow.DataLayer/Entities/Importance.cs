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

        ICollection<Order> Orders { get; set; } = null!;

        public Importance(long id,
            string name) : base(id)
        {
            Name = name;
        }
    }
}
