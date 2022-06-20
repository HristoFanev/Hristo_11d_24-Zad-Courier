using Hristo_11d__24.Data;
using Hristo_11d__24.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hristo_11d__24.Business
{
    internal class ParcelBusiness
    {
        private ParcelContext parcelContext = new ParcelContext();

        public List<Parcel> GetAll()
        {

            return parcelContext.Parcels.Include("ParcelType").ToList();

        }
        public Parcel Get(int id)
        {
            Parcel fndParcel = parcelContext.Parcels.Find(id);
            if (fndParcel != null)
            {
                parcelContext.Entry(fndParcel).Reference(x => x.ParcelType).Load();
            }
            return fndParcel;

        }
        public void Add(Parcel parcel)
        {
            parcelContext.Parcels.Add(parcel);
            parcelContext.SaveChanges();
        }
        public void Update(int id, Parcel parcel)
        {
            Parcel updParcel = parcelContext.Parcels.Find(id);
            if (updParcel == null)
            {
                return;
            }
            updParcel.Name = parcel.Name;
            updParcel.Description = parcel.Description;
            updParcel.Price = parcel.Price;
            updParcel.Weight = parcel.Weight;
            updParcel.ParcelTypeId = parcel.ParcelTypeId;
            parcelContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Parcel delParcel = parcelContext.Parcels.Find(id);
            parcelContext.Parcels.Remove(delParcel);
            parcelContext.SaveChanges();
        }
    }
}
