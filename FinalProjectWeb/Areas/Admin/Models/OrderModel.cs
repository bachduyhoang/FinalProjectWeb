using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectWeb.Areas.Admin.Models
{
    public class OrderModel
    {
        public int orderID { get; set; }
        public string searchWord { get; set; }
        public int currentPage { get; set; }
        public int totalPage { get; set; }
        public List<Order> list { get; set; }
    }
}