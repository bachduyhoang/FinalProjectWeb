using BLL.BLL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectWeb.Areas.Admin.Models
{
    public class OrderDetailModel
    {
        public Order order { get; set; }
        public List<OderDetailDTO> list { get; set; }
    }
}