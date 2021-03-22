using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectWeb.Areas.Admin.Models
{
    public class DiscountModel
    {
        public string discountID { get; set; }
        public string searchWord { get; set; }
        public int currentPage { get; set; }
        public int totalPage { get; set; }
        public List<Discount> list { get; set; }
    }
}