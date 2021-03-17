﻿
using BLL;
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
            var p = dao.GetProduct(id);
            return View(p);
        }

        public ActionResult Brand(string brand, int index = 1)
        {
            int pageSize = 1;
            ProductBLL dao = new ProductBLL();
            int totalRecord = 0;
            var listBrand = dao.GetListOfBrand(brand, ref totalRecord, index,pageSize);
            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.Index = index;
            ViewBag.MaxPage = maxPage;
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