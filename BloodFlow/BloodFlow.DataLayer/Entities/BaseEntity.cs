using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        protected BaseEntity(long id) => Id = id;
    }
}
