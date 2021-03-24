using BLL.BLL;
using FinalProjectWeb.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectWeb.Areas.Admin.Controllers
{
    public class ActivityLogController : Controller
    {
        // GET: Admin/ActivityLog
        public ActionResult Index()
        {
            ActivityLogBLL bll = new ActivityLogBLL();
            ActivityLogModel model = new ActivityLogModel();
            model.currentPage = 1;
            model.totalPage = bll.CountPage("");
            model.list = bll.GetList(1, "");
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ActivityLogModel model)
        {
            if(model.searchWord == null)
            {
                model.searchWord = "";
            }
            if(model.currentPage == 0)
            {
                model.currentPage = 1;
            }
            ActivityLogBLL bll = new ActivityLogBLL();
            model.list = bll.GetList(model.currentPage, model.searchWord);
            model.totalPage = bll.CountPage(model.searchWord);
            return View(model);
        }
    }
}