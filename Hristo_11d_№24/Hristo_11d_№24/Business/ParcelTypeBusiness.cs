using Hristo_11d__24.Data;
using Hristo_11d__24.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hristo_11d__24.Business
{
    internal class ParcelTypeBusiness
    {
        private ParcelContext parcelTypeContext = new ParcelContext();
        public List<ParcelType> GetAllTypes()
        {
            return parcelTypeContext.ParcelTypes.ToList();

        }
        public string GetType(int id)
        {
            return parcelTypeContext.ParcelTypes.Find(id).Name;
        }
    }
}
