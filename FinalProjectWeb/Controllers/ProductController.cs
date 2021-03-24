
using BLL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectWeb.Controllers
{
    public class ProductController : Controller
    {
        // Get: Product
        public ActionResult Detail(int id)
        {
            ProductBLL dao = new ProductBLL();
            Product p = dao.GetProduct(id);
            int total = 0;
            ViewBag.ListRelated = dao.GetListOfBrand(p.brandID, ref total);
            if(total > 4)
            {
                total = 4;
            }
            ViewBag.Size = total;
            ViewBag.Category = p.brandID;
            return View(p);
        }

        public ActionResult Brand(string brand, int index = 1)
        {
            int pageSize = 20;
            ProductBLL dao = new ProductBLL();
            int totalRecord = 0;
            var listBrand = dao.GetListOfBrand(brand, ref totalRecord, index,pageSize);
            int totalPage = (totalRecord / pageSize);
            if(totalPage % pageSize != 0)
            {
                totalPage++;
            }

            ViewBag.TotalPage = totalPage;
            ViewBag.Index = index;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = index + 1;
            ViewBag.Prev = index - 1;
            ViewBag.Brand = brand;
            return View(listBrand);
        }

        [ChildActionOnly]
        public ActionResult ListBrand()
        {
            ProductBLL dao = new ProductBLL();
            var list = dao.GetListBrand();
            return View(list);
        }
    }
}