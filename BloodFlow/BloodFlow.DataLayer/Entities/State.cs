using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Entities
{
    [Table("state")]
    public class State : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        public ICollection<Session>? Sessions { get; set; }

        public State(long id,
            string name) : base(id)
        {
            Name = name;
        }
    }
}
