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
        public ActionResult Index(string name="", int index = 1)
        {
            int pageSize = 20;
            ProductBLL dao = new ProductBLL();
            int totalRecord = 0;
            var listName = dao.GetListAllProduct(name, ref totalRecord, index, pageSize);
            int totalPage = (totalRecord / pageSize);
            if (totalPage % pageSize != 0)
            {
                totalPage++;
            }

            ViewBag.TotalPage = totalPage;
            ViewBag.Index = index;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = index + 1;
            ViewBag.Prev = index - 1;
            ViewBag.Name = name;
            return View(listName);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        public ActionResult Delivery()
        {
            return View();
        }

        public ActionResult News()
        {
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

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account", new { area =  " "});
        }

    }
}