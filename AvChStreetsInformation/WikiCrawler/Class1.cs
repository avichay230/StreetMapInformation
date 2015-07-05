using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using wikiClasses;

namespace WikiCrawler
{
    public class Wikipedia
    {
        public string GetDescription(string StreetName)
        {
            var uri = string.Format("https://he.wikipedia.org/wiki/{0}", StreetName);
            WebClient wc = new WebClient();
            var json = wc.DownloadString(uri);
        }
    }
}