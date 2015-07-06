using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvChStreetsInformation.Controllers
{
    public class InformationController : Controller
    {
        // GET: Information
        public ActionResult GetCategories(string id)
        {
            WikiCrawler.Wikipedia wkp = new WikiCrawler.Wikipedia();
            var StreetDesc = wkp.GetDescription(id);
            return Json(StreetDesc, JsonRequestBehavior.AllowGet);
        }
    }
}
