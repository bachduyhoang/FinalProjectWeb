using BLL.BLL;
using DAL.EF;
using FinalProjectWeb.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectWeb.Areas.Admin.Controllers
{
    public class DiscountController : BaseController
    {
        // GET: Admin/Discount
        public ActionResult Index()
        {
            var dll = new DiscountCodeBLL();
            var model = new DiscountModel();
            model.currentPage = 1;
            model.totalPage = dll.CountPage("");
            model.list = dll.GetList(1, "");

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(DiscountModel model)
        {
            if(model.searchWord == null)
            {
                model.searchWord = "";
            }
            if(model.currentPage == 0)
            {
                model.currentPage = 1;
            }
            var dll = new DiscountCodeBLL();
            model.totalPage = dll.CountPage(model.searchWord);
            model.list = dll.GetList(model.currentPage, model.searchWord);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Discount discount)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DiscountCodeBLL bll = new DiscountCodeBLL();
                    int result = bll.CheckIdExisted(discount.discountID);
                    if(result == 0)
                    {
                        bll.Insert(discount);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "ID EXISTED");
                        
                    }
                    return View(discount);
                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(DiscountModel model)
        {
            DiscountCodeBLL bll = new DiscountCodeBLL();
            bll.Delete(model.discountID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string DiscountID)
        {
            DiscountCodeBLL bll = new DiscountCodeBLL();
            var dis = bll.Find(DiscountID);
            return View(dis);
        }

        [HttpPost]
        public ActionResult Edit(Discount dis)
        {
            if (ModelState.IsValid)
            {
                DiscountCodeBLL bll = new DiscountCodeBLL();
                bll.Update(dis);
                return RedirectToAction("Index");
            }

            return View(dis);
        }
    }
}