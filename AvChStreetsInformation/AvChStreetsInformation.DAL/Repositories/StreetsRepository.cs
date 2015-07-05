using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvChStreetsInformation.DAL.Repositories
{
    public class StreetsRepository
    {
        public int SetStreet(Streets street)
        {
            using (var context = new Database1Entities())
            {
                var st = context.Streets.Where(s => s.Id == street.Id).FirstOrDefault();
                if (st == null)
                {
                    context.Streets.Add(street);
                }
                else
                {
                    st.StreetDesc = street.StreetDesc;
                    st.StreetName = street.StreetName;
                }
                context.SaveChanges();
                return street.Id;
            }
        }
        public Streets GetStreet(string streetName)
        {
            using (var context = new Database1Entities())
            {
                return context.Streets.Where(s => s.StreetName == streetName).FirstOrDefault();
            }
        }

        public static DbGeography CreatePoint(double lat, double lon, int srid)
        {
            string wkt = String.Format("POINT({0} {1})", lon, lat);

            return DbGeography.PointFromText(wkt, srid);
        }

    }

}
