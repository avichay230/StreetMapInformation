using AvChStreetsInformation.DAL;
using AvChStreetsInformation.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter street name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter details:");
            var details = Console.ReadLine();

            Console.WriteLine("Enter long:");
            var longitu = Console.ReadLine();

            Console.WriteLine("Enter lat:");
            var langitu = Console.ReadLine();

            StreetsRepository sr = new StreetsRepository();
            Streets st = new Streets();
            st.StreetName = name;
            st.StreetDesc = details;
            st.point = StreetsRepository.CreatePoint(double.Parse(langitu), double.Parse(longitu), 4326);
            sr.SetStreet(st);

        }


    }
}
