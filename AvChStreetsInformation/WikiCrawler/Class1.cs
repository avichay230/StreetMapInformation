using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WikiCrawler
{
    public class Wikipedia
    {
        public List<string> GetDescription(string StreetName)
        {
            List<string> categories = new List<string>();
            var uri = string.Format("https://he.wikipedia.org/w/api.php?format=xml&action=query&prop=categories&titles={0}", StreetName);
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            var xml = wc.DownloadString(uri);
            
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xml);
            
            XmlNodeList elemList = xd.GetElementsByTagName("cl");
            for (int i = 0; i < elemList.Count; i++)
            {
                categories.Add(elemList[i].Attributes["title"].Value.Replace("קטגוריה:", "").Trim());
            }
            return categories;
        }
    }
}