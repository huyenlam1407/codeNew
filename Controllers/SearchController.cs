using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROJECT.Models;

namespace PROJECT.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
       
        DBQLBANHANGEntities database  = new DBQLBANHANGEntities();
        public ActionResult Index(string Search)
        {
            var lstSP = database.tblProducts.Where(n => n.nameProduct.Contains(Search));
            return View(lstSP.OrderBy(n=>n.nameProduct));
        }
        
    }
}
