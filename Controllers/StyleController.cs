using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROJECT.Models;

namespace PROJECT.Controllers
{
    public class StyleController : Controller
    {
        DBQLBANHANGEntities database = new DBQLBANHANGEntities();
        [ChildActionOnly]
        public ActionResult Index()
        {
            var list = database.tblStyles.ToList();
            ViewBag.listStyle = list;
            return PartialView(list);
        }

    }
}