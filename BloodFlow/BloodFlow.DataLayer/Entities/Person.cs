using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Entities
{
    [Table("person")]
    public class Person : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("surname")]
        public string Surname { get; set; }

        [Column("date_of_birthday")]
        public DateTime DateOfBirthday { get; set; }

        [Column("photo_link")]
        public string PhotoLink { get; set; }

        public ICollection<PersonContact> PersonContacts { get; set; } = null!;

        public Person(long id,
            string name,
            string surname,
            DateTime dateOfBirthday,
            string photoLink) : base(id)
        {
            Name = name;
            Surname = surname;
            DateOfBirthday = dateOfBirthday;
            PhotoLink = photoLink;
        }
    }
}
