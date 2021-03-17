using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using BLL;
using DAL.EF;

namespace FinalProjectWeb.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(string txtSearch, int page = 1, int size = 5)
        {
            var iplProduct = new ProductBLL();
            //ViewBag.Search = txtSearch;
            var model = iplProduct.GetListPaging(txtSearch, page, size);
            return View(model);
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]

        public ActionResult Create(Product product)
        {
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(product.imageFile.FileName);
                string extension = Path.GetExtension(product.imageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                product.imageLink = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                product.imageFile.SaveAs(fileName);
                if (ModelState.IsValid)
                {
                    var iplProduct = new ProductBLL();
                    int res = iplProduct.Create(product);
                    if (res > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Create fail!");
                    }

                }
                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
