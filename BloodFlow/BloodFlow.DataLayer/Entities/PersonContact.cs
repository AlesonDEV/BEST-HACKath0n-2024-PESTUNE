using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Entities
{
    [Table("person_contact")]
    public class PersonContact : BaseEntity
    {
        // Overhiding the name of the variable from base entity and
        // set not mapped to not create this column in the database
        [NotMapped]
        public new long Id { get; set; }

        [Column("peson_id")]
        [ForeignKey(nameof(Person))]
        public long PersonId { get; set; }

        [Column("contact_type_id")]
        [ForeignKey(nameof(ContactType))]
        public long ContactTypeId { get; set; }

        [Column("contact_value")]
        public string ContactValue { get; set; } = null!;

        public Person Person { get; set; } = null!;

        public ContactType ContactType { get; set; } = null!;

        public PersonContact() : base(0) { }

        public PersonContact(long id,
            long personId,
            long contactTypeId,
            string contactValue) : base(id)
        {
            PersonId = personId;
            ContactTypeId = contactTypeId;
            ContactValue = contactValue;
        }
    }
}
