using BLL;
using DAL.EF;
using FinalProjectWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProductBLL product = new ProductBLL();
            List<Product> p = product.GetListNew();
            return View(p);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult Brand()
        {
            ProductBLL product = new ProductBLL();
            var p = product.GetListBrand();
            return View(p);
        }
        [ChildActionOnly]
        public ActionResult Slide()
        {
            ProductBLL product = new ProductBLL();
            List<Product> p = product.GetListNew();
            return View(p);
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session["CartSession"];
            var list = new List<CartModels>();
            if (cart != null)
            {
                list = (List<CartModels>)cart;
            }
            return PartialView(list);
        }
    }
}