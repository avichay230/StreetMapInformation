using AvChStreetsInformation.DAL;
using AvChStreetsInformation.DAL.Repositories;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MuniCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10000; i++)
            {
                StartCrawl(i);
                if (i % 25 == 0)
                    Console.WriteLine(string.Format("{0} street crawle!", i));
            }
        }
        
        private static void StartCrawl(int p)
        {
            var url = string.Format("https://www.jerusalem.muni.il/City/Streetnames/Pages/Street.aspx?streetSemel={0}", p);
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            var html = wc.DownloadString(url);
            var obj = ParseData(html);
            if (string.IsNullOrEmpty(obj.StreetName))
                return;
            obj.Id = p;
            SaveData(obj);
        }

        private static void SaveData(Streets obj)
        {
            StreetsRepository sr = new StreetsRepository();
            sr.SetStreet(obj);
        }

        /// <summary>
        /// street name:
        /// <div class="center_content"><div class="page_title" >המרפא</div>
        /// street desc:
        /// #ctl00_SPWebPartManager1_g_817f4b33_8ca0_47a9_9c1f_f0b7f9781237 > div > div.event_main_unit > div.text_div
        /// </summary>
        /// <param name="p"></param>
        private static Streets ParseData(string html)
        {
            HtmlDocument hd = new HtmlDocument();
            hd.LoadHtml(html);

            Streets st = new Streets();

            HtmlNode sn = hd.DocumentNode.SelectSingleNode("//div[@class='center_content']//div[@class='page_title']");
            st.StreetName = NormalizeText(sn.InnerText);

            HtmlNode sd = hd.DocumentNode.SelectSingleNode("//div[@class='event_main_unit']//div[@class='text_div']");
            st.StreetDesc = NormalizeText(sd.InnerText);

            return st;
        }

        private static string NormalizeText(string p)
        {
            //this will remov \r\n occurnces
            p = p.Replace("\r\n", string.Empty);
            p = p.Replace("\t", " ");

            //this will remove extra spaces
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(@"[ ]{2,}", options);     
            p = regex.Replace(p, @" ");
            return p.Trim();
        }
    }
}
