using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROJECT.Models;

namespace PROJECT.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
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
               
                var check_Name = database.tblUsers.Where(s => s.userName == _user.userName).FirstOrDefault();
                var check_Pass = database.tblUsers.Where(s => s.userPass == _user.userPass).FirstOrDefault();
                if (check_Name == null || check_Pass == null)
                {
                    if (check_Name == null)
                        ViewBag.ErrorName = "Tài khoản không tồn tại";
                    if (check_Pass == null)
                        ViewBag.ErrorPass = "Sai mật khẩu";
                    return View("Login");
                }
                else
                {
                    Session["userName"] = _user.userName;
                    Session["userID"] = _user.userID;
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                return View("Login");
            }
           
            
        }
        public ActionResult Register()
        {
            return View();

        }
        public ActionResult AuthenRegister(tblUser _user)
        {
            try
            {
                database.tblUsers.Add(_user);
                database.SaveChanges();
                return RedirectToAction("Login");

            }
            catch {
                return View("Register");

            }

        }
        public ActionResult Logout(tblUser _user)
        {
            Session["userID"] = _user.userID ;
            Session["userName"] = _user.userName;

            Session.Clear();
            
            return RedirectToAction("Login", "Login");
        }
    }
}