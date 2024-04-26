using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Entities
{
    [Table("city")]
    public class City : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        public ICollection<Street>? Streets { get; set; }

        public City(long id,
            string name) : base(id)
        {
            Name = name;
        }
    }
}
