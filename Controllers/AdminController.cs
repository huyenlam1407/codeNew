using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROJECT.Models;

namespace PROJECT.Controllers
{
    public class AdminController : Controller
    {
        // GET: Product
        DBQLBANHANGEntities database = new DBQLBANHANGEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthenLogin(tblUser _user)
        {
            try
            {

                var check_Email = database.tblUsers.Where(s => s.userName == _user.userName).FirstOrDefault();
                var check_Pass = database.tblUsers.Where(s => s.userPass == _user.userPass).FirstOrDefault();
                var check_Role = database.tblUsers.Where(s => s.userRole == _user.userRole).FirstOrDefault();
                if (check_Email == null || check_Pass == null || check_Role == null)
                {
                    if (check_Email == null)
                        ViewBag.ErrorName = "Tài khoản không tồn tại";
                    if (check_Pass == null)
                        ViewBag.ErrorPass = "Sai mật khẩu";
                    if (check_Role == null)
                        ViewBag.ErrorRole = "Bạn không có quyền truy cập";
                    return View("Login");
                }
                else
                {
                    Session["userName"] = _user.userName;
                    Session["userID"] = _user.userID;
                    Session["userRole"] = _user.userRole;
                    return RedirectToAction("SanPham", "Admin");
                }
            }
            catch
            {
                return View("Login");
            }


        }
        public ActionResult SanPham()
        {
            if (Session["userRole"] != null)
            {
                return View(database.tblProducts.ToList());

            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblProduct product)
        {
            database.tblProducts.Add(product);
            database.SaveChanges();
            return RedirectToAction("SanPham");
        }
        public ActionResult Details(int id)
        {
            return View(database.tblProducts.Where(s => s.ID == id).FirstOrDefault());

        }
        public ActionResult Edit(int id)
        {
            return View(database.tblProducts.Where(s => s.ID == id).FirstOrDefault());

        }
        [HttpPost]
        public ActionResult Edit(int id, tblProduct product)
        {
            database.Entry(product).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("SanPham");

        }
        public ActionResult Delete(int id)
        {
            return View(database.tblProducts.Where(s => s.ID == id).FirstOrDefault());

        }
        [HttpPost]
        public ActionResult Delete(int id, tblProduct product)
        {
            product = database.tblProducts.Where(s => s.ID == id).FirstOrDefault();
            database.tblProducts.Remove(product);
            database.SaveChanges();
            return RedirectToAction("SanPham");

        }
        public ActionResult DanhMuc()
        {
            if (Session["userRole"] != null)
            {
                return View(database.tblStyles.ToList());

            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult Create1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create1(tblStyle sty)
        {
            database.tblStyles.Add(sty);
            database.SaveChanges();
            return RedirectToAction("DanhMuc");
        }
        public ActionResult Details1(int id)
        {
            return View(database.tblStyles.Where(s => s.ID == id).FirstOrDefault());

        }
        public ActionResult Edit1(int id)
        {
            return View(database.tblStyles.Where(s => s.ID == id).FirstOrDefault());

        }
        [HttpPost]
        public ActionResult Edit1(int id, tblStyle sty)
        {
            database.Entry(sty).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("DanhMuc");

        }
        public ActionResult Delete1(int id)
        {
            return View(database.tblStyles.Where(s => s.ID == id).FirstOrDefault());

        }
        [HttpPost]
        public ActionResult Delete1(int id, tblStyle sty)
        {
            sty = database.tblStyles.Where(s => s.ID == id).FirstOrDefault();
            database.tblStyles.Remove(sty);
            database.SaveChanges();
            return RedirectToAction("DanhMuc");

        }
        public ActionResult DonHang()
        {
            List<tblDetailBill> proList = database.tblDetailBills.ToList();
            if (Session["userRole"] != null)
            {
                List<ProductView> productVM = proList.Select(
                   x => new ProductView
                   {
                       IDBill = x.IDBill,
                       CodeProduct = x.CodeProduct,
                       QuantityProduct = x.QuantityProduct,
                       PriceProductBuying = x.PriceProductBuying,
                       TotalMoney = x.TotalMoney,
                       codeCus = x.tblBill.codeCus,
                       BillDate = x.tblBill.BillDate
                   }
                   ).ToList();
                return View(productVM);

            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }


        }
    }
}