using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.EF;
namespace FinalProjectWeb.Areas.Admin.Models
{
    public class UserModel
    {
        public string userID { get; set; }
        public string searchWord { get; set; }
        public int currentPage { get; set; }
        public int totalPage { get; set; }
        public List<User> list { get; set; }
    }
}