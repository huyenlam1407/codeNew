using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROJECT.Models;

namespace PROJECT.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        DBQLBANHANGEntities database = new DBQLBANHANGEntities();
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddToCart(int id)
        {
            var pro = database.tblProducts.SingleOrDefault(s => s.ID == id);
            if(pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public ActionResult ShowTocart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCart", "ShoppingCart");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult Update_Quantity_Shopping( FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["ID_Product"]);
            int quantity = int.Parse(form["Quantity"]);
            cart.Update_Quantity_Shopping(id_pro, quantity);
            return RedirectToAction("ShowToCart", "ShoppingCart");


        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public PartialViewResult BagCart()
        {
            int total_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)

                total_item = cart.Total_Quantity_in_Cart();
            ViewBag.QuantityCart = total_item;
            return PartialView("BagCart");

        }
        public ActionResult ShoppingSuccess()
        {
            return View();
        }
        public ActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthenCheckOut(FormCollection form)
        {
            if (Session["userID"] != null)
            {
                Cart cart = Session["Cart"] as Cart;

                tblCustumer _cus = new tblCustumer();
                tblBill _bill = new tblBill();
                _bill.BillDate = DateTime.Now;
                _cus.codeCus = form["CodeCus"];
                _bill.codeCus = _cus.codeCus;
                _cus.nameCus = form["NameCus"];
                _cus.emailCus = form["Email"];
                _cus.addressCus = form["AddressCus"];
                _cus.phoneCus = form["PhoneCus"];
                database.tblBills.Add(_bill);
                database.tblCustumers.Add(_cus);
                foreach (var item in cart.Items)
                {
                    tblDetailBill _detail = new tblDetailBill();
                    _detail.CodeProduct = item._shopping_product.codeProduct;
                    _detail.IDBill = _bill.IDBill;
                    _detail.ID = item._shopping_product.ID;
                    _detail.PriceProductBuying = item._shopping_product.priceProductInput;
                    _detail.QuantityProduct = item._shopping_quantity;
                    database.tblDetailBills.Add(_detail);
                }
                database.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("ShoppingSuccess", "ShoppingCart");
            }
            else
            {
                return RedirectToAction("Login", "Login");

            }

        }
    }
}