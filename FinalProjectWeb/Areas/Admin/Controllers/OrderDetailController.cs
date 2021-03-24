using BLL.BLL;
using FinalProjectWeb.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectWeb.Areas.Admin.Controllers
{
    public class OrderDetailController : Controller
    {
        // GET: Admin/OrderDetail
        public ActionResult Index()
        {
            OrderBLL bll = new OrderBLL();
            OrderModel model = new OrderModel();
            model.list = bll.GetList(1, "");
            model.currentPage = 1;
            model.totalPage = bll.CountPage("");
            return View(model);
            
        }
        [HttpPost]
        public ActionResult Index(OrderModel model)
        {
            OrderBLL bll = new OrderBLL();
            if(model.searchWord == null)
            {
                model.searchWord = "";
            }
            if(model.currentPage == 0)
            {
                model.currentPage = 1;
            }
            model.list = bll.GetList(model.currentPage, model.searchWord);
            model.totalPage = bll.CountPage(model.searchWord);
            return View(model);

        }
        [HttpPost]
        public ActionResult Detail(OrderModel model)
        {
            OrderBLL orderBLL = new OrderBLL();
            OrderDetailBLL bll = new OrderDetailBLL();
            OrderDetailModel detailModel = new OrderDetailModel();
            detailModel.order = orderBLL.Find(model.orderID);
            detailModel.list = bll.GetList(model.orderID);
            
            return View(detailModel);
        }

        [HttpPost]
        public ActionResult Delete(OrderModel model)
        {
            OrderBLL bll = new OrderBLL();
            bll.Delete(model.orderID);
            return RedirectToAction("Index","OrderDetail");
        }
    }
}