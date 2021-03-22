using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL.EF;
using System.Web.Security;


namespace FinalProjectWeb.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index(string txtSearch, int page = 1, int size = 5)
        {
            var iplProduct = new UserBLL();
            ViewBag.Search = txtSearch;
            var model = iplProduct.GetListPaging(txtSearch, page, size);
            return View(model);
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(string id)
        {
            var iplProduct = new UserBLL();
            User u = iplProduct.GetUserByID(id);
            return View(u);
        }

        // POST: Admin/User/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, User u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var iplProduct = new UserBLL();
                    var res = iplProduct.UpdateUser(u);
                    if (res)
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Update Fail!");
                    }
                }
                return View("Index");
            }catch(Exception e)
            {
                return View();
            }
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(string id)
        {
            var iplProduct = new UserBLL();
            User u = iplProduct.GetUserByID(id);
            return View(u);
        }

        // POST: Admin/User/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, User u)
        {
            try
            {
                var iplProduct = new UserBLL();
                var res = iplProduct.DeleteUser(id);
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
