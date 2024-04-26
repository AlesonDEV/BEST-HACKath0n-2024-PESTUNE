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

        [Column("house_number")]
        public int HouseNumber { get; set; }

        [Column("street_id")]
        [ForeignKey(nameof(Street))]
        public long StreetId { get; set; }

        public Street Street { get; set; } = null!;

        public ICollection<PersonContact> PersonContacts { get; set; } = null!;

        public Person(long id,
            string name,
            string surname,
            DateTime dateOfBirthday,
            string photoLink,
            int houseNumber,
            long streetId) : base(id)
        {
            Name = name;
            Surname = surname;
            DateOfBirthday = dateOfBirthday;
            PhotoLink = photoLink;
            HouseNumber = houseNumber;
            StreetId = streetId;
        }
    }
}
