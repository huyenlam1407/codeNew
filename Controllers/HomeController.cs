using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROJECT.Models;
using PagedList.Mvc;
using PagedList;
using System.Configuration;

namespace DEMO5.Controllers
{
    public class HomeController : Controller
    {
        
        DBQLBANHANGEntities database = new DBQLBANHANGEntities();
       
        public ActionResult Index(int? style, int? page)
        {
            int pageSize = 16;

            // Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // Nếu page = null thì đặt lại page là 1.
            if (page == null) page = 1;

            IEnumerable<tblProduct> products;

            if (style != null)
            {
                products = database.tblProducts.Where(s => s.IDStyle == style).ToList();
            }
            else
            {
                products = database.tblProducts.ToList();
            }

            // Trả về các product được phân trang theo kích thước và số trang.
            return View(products.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult about_us()
        {
            return View();

        }
        public ActionResult faqs()
        {
            return View();

        }
        public ActionResult produce_layout_1(int id)
        {
            return View(database.tblProducts.Where(s => s.ID == id).FirstOrDefault());

        }
        
    }
}