using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL
{
    public class OderDetailDTO
    {
        public int orderDetailID { get; set; }
        public int? orderID { get; set; }
        public int? productID { get; set; }
        public string productName { get; set; }
        public string imageLink { get; set; }
        public double? price { get; set; }
        public int? quantity { get; set; }
        public double? total { get; set; }


    }
}
