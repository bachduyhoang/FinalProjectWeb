using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectWeb.Models
{
    [Serializable]
    public class CartModels
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}