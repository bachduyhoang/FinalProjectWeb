using BLL;
using FinalProjectWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace FinalProjectWeb.Controllers
{
    public class CartController : Controller
    {
        private string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartModels>();
            if (cart != null)
            {
                list = (List<CartModels>)cart;
            }
            return View(list);
        }

        public ActionResult Add(int i, int q)
        {
            ProductBLL dao = new ProductBLL();
            var product = dao.GetProduct(i);

            List<CartModels> cart = (List<CartModels>)Session[CartSession];
            if (cart == null)
            {
                cart = new List<CartModels>();
            }

            var item = cart.FirstOrDefault(a => a.Product.productID == product.productID);

            if (item != null)
            {
                item.Quantity += q;
            }
            else
            {
                cart.Add(new CartModels { Product = product, Quantity = q });
            }

            Session[CartSession] = cart;

            return RedirectToAction("Index");
        }

        public JsonResult Update(string cart)
        {
            if (cart != null)
            {
                var cartJson = new JavaScriptSerializer().Deserialize<List<CartModels>>(cart);
                List<CartModels> cartSession = (List<CartModels>)Session[CartSession];

                foreach (var item in cartSession)
                {
                    var jsonItem = cartJson.SingleOrDefault(x => x.Product.productID == item.Product.productID);
                    if (jsonItem != null)
                    {
                        item.Quantity = jsonItem.Quantity;
                    }
                }
            }

            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete()
        {
            List<CartModels> cart = (List<CartModels>)Session[CartSession];
            if (cart != null)
            {
                Session[CartSession] = null;
            }

            return Json(new
            {
                status = true
            });

        }

        public JsonResult DeleteItem(int id)
        {
            List<CartModels> cart = (List<CartModels>)Session[CartSession];
            if (cart != null)
            {
                cart.RemoveAll(x => x.Product.productID == id);
                Session[CartSession] = cart;
            }
            return Json(new
            {
                status = true
            });
        }
    }
}