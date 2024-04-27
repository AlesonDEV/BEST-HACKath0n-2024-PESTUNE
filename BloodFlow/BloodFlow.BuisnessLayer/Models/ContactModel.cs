using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Models
{
    public class ContactModel
    {
        public int PersonId { get; set; }

        public int ContactTypeId { get; set; }

        public string ContactValue { get; set; }
    }
}
