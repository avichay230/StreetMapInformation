using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MuniCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            StartCrawl(5501);
        }

        private static void StartCrawl(int p)
        {
            var url = string.Format("https://www.jerusalem.muni.il/City/Streetnames/Pages/Street.aspx?streetSemel={0}", p);
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            var html = wc.DownloadString(url);
            Console.WriteLine(html);
        }
    }
}
