﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.BuisnessLayer.Models
{
    public class FilterSearchModel
    {
        public long? BloodTypeId { get; set; }

        public long? ImportanceId { get; set; }

        public DateTime? EndTime { get; set; }

        public int? Distance { get; set; }
    }
}
