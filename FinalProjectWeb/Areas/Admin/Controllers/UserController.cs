using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL.EF;
using System.Web.Security;
using FinalProjectWeb.Areas.Admin.Models;

namespace FinalProjectWeb.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string txtSearch, int index = 1)
        {
            var iplProduct = new UserBLL();
            ViewBag.Search = txtSearch;
            int totalPage = 0;
            var model = iplProduct.GetListPagingHand(txtSearch,ref totalPage, index);
            List<string> listPage = iplProduct.Paging(index, totalPage);
            ViewBag.TotalPage = totalPage;
            ViewBag.Index = index;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = index + 1;
            ViewBag.Prev = index - 1;
            ViewBag.ListPage = listPage;

            return View(model);

            //UserModel model = new UserModel();
            //model.list = iplProduct.GetList(1, "");
            //model.currentPage = 1;
            //model.totalPage = iplProduct.CountPage("");
            //return View(model);
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
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(string id)
        {
            //var iplProduct = new UserBLL();
            //User u = iplProduct.GetUserByID(id);
            //return View(u);
            try
            {
                var iplProduct = new UserBLL();
                iplProduct.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Admin/User/Delete/5
        //[HttpPost]
        //public ActionResult Delete(string id, string ii)
        //{
        //    try
        //    {
        //        var iplProduct = new UserBLL();
        //        iplProduct.DeleteUser(id);
        //        return RedirectToAction("Index");

        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Account", new { area = "" });
        }

    }
}
