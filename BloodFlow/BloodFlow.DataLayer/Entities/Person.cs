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
        // Add relationship with FluentApi
        [Column("name")]
        public string Name { get; set; }

        [Column("surname")]
        public string Surname { get; set; }

        [Column("date_of_birthday")]
        public DateTime DateOfBirthday { get; set; }

        [Column("photo_link")]
        public string PhotoLink { get; set; }

        [Column("house_number")]
        public string? HouseNumber { get; set; }

        [Column("street_id")]
        [ForeignKey(nameof(Street))]
        public int? StreetId { get; set; }

        [Column("contact_id")]
        [ForeignKey(nameof(Contact))]
        public int? ContactId { get; set; }

        public Street? Street { get; set; }

        public Contact? Contact { get; set; }

        public Donor Donor { get; set; } = null!;

        public Person() : base(0) { }

        public Person(int id,
            string name,
            string surname,
            DateTime dateOfBirthday,
            string photoLink,
            string houseNumber,
            int streetId) : base(id)
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
