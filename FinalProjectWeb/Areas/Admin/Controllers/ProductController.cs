using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using BLL;
using DAL.EF;
using DAL.DAL;
using System.Web.Security;

namespace FinalProjectWeb.Areas.Admin.Controllers
{
    public class ProductController : BaseController
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
            var iplProduct = new ProductModel();
            var Brand = iplProduct.GetListBrand();
            ViewBag.Brand = new SelectList(Brand, "brandID", "brandName");
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]

        public ActionResult Create(Product product)
        {
            try
            {
                var iplProduct = new ProductBLL();
                var Brand = iplProduct.GetListBrandThy();
                ViewBag.Brand = new SelectList(Brand, "brandID", "brandName");
                string fileName = Path.GetFileNameWithoutExtension(product.imageFile.FileName);
                string extension = Path.GetExtension(product.imageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                product.imageLink = "~/Areas/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Areas/Image/"), fileName);
                product.imageFile.SaveAs(fileName);
                if (ModelState.IsValid)
                {
                    int res = iplProduct.Create(product);
                    if (res > 0)
                    {
                        int id = iplProduct.GetMaxID();
                        iplProduct.ActivityLog(id);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Create fail!");
                    }
                    return View(product);
                }
                else
                {
                    return View();
                }
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
            var Brand = iplProduct.GetListBrand();
            ViewBag.Brand = new SelectList(Brand, "brandID", "brandName");
            Product p = iplProduct.GetProductById(id);
            return View(p);
        }
        public ActionResult Delete(int id)
        {
            try
            {
                var iplProduct = new ProductBLL();
                iplProduct.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product p)
        {
            var iplProduct = new ProductBLL();
            string fileName = Path.GetFileNameWithoutExtension(p.imageFile.FileName);
            string extension = Path.GetExtension(p.imageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            p.imageLink = "~/Areas/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Areas/Image/"), fileName);
            p.imageFile.SaveAs(fileName);
            if (ModelState.IsValid)
            {
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
    }
}
