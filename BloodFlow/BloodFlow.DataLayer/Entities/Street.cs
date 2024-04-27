using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Entities
{
    [Table("street")]
    public class Street : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("city_id")]
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }

        public City City { get; set; } = null!;

        public ICollection<DonorCenter>? DonorCenters { get; set; }

        public Street() : base(0) { }

        public Street(int id,
            string name,
            int cityId) : base(id)
        {
            Name = name;
            CityId = cityId;
        }
    }
}
