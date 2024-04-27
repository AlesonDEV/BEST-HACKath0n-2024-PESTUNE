using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Entities
{
    [Table("contact_type")]
    public class ContactType : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        public ICollection<DonorCenterContact>? DonorCenterContacts { get; set; }

        public ICollection<PersonContact>? PersonContacts { get; set; }

        public ContactType(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
