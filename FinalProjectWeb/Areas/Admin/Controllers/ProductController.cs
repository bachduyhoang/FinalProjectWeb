using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using BLL;
using DAL.EF;
using System.Web.Security;

namespace FinalProjectWeb.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(string txtSearch, int page = 1, int size = 5)
        {
            var iplProduct = new ProductBLL();
            ViewBag.Search = txtSearch;
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
                        int id = iplProduct.GetIdProduct();
                        iplProduct.ActivityLog(id);
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
            var iplProduct = new ProductBLL();
            Product p = iplProduct.GetProductById(id);
            return View(p);
        }
        public ActionResult Delete(int id)
        {
            var iplProduct = new ProductBLL();
            Product p = iplProduct.GetProductById(id);
            return View(p);
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product p)
        {
            string fileName = Path.GetFileNameWithoutExtension(p.imageFile.FileName);
            string extension = Path.GetExtension(p.imageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            p.imageLink = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            p.imageFile.SaveAs(fileName);
            if (ModelState.IsValid)
            {
                var iplProduct = new ProductBLL();
                p.productID = id;
                var result = iplProduct.UpdateProduct(p);
                if (result)
                {
                    iplProduct.ActivityLog(id);
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Update Fail!");
                }
            }
            return View("Index");
        }

        // POST: Admin/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product p)
        {
            try
            {
                var iplProduct = new ProductBLL();
                var res = iplProduct.DeleteProduct(id);
                if (res)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Delete Fail!");
                    return View("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
