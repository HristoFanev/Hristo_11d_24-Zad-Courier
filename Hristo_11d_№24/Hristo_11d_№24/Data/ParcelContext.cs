using Hristo_11d__24.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hristo_11d__24.Data
{
    class ParcelContext : DbContext
    {
        public ParcelContext()
          : base("name=ParcelContext")
        {
        }
        public DbSet<Parcel> Parcels { get; set; }
        public DbSet<ParcelType> ParcelTypes { get; set; }
    }
}
