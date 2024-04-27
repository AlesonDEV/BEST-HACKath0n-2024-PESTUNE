using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Entities
{
    [Table("contact")]
    public class Contact : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        public Contact(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
