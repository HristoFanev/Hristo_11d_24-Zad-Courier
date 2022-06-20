﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hristo_11d__24.Data.Models
{
    class ParcelType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Parcel> Parcels { get; set; }
    }
}
