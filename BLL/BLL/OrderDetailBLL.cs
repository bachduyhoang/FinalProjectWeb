using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL
{
    public class OrderDetailBLL
    {
        DBContext context = null;
        public OrderDetailBLL()
        {
            context = new DBContext();
        }

        public List<OderDetailDTO> GetList(int orderID)
        {
            var list = context.OrderDetails.Join(
                    context.Products,
                    orderDetail => orderDetail.productID,
                    product => product.productID,
                    (orderDetail, product) => new OderDetailDTO
                    {
                        orderDetailID = orderDetail.orderDetailID,
                        orderID = orderDetail.orderID,
                        productID = orderDetail.productID,
                        productName = product.productName,
                        imageLink = product.imageLink,
                        price = product.price,
                        quantity = orderDetail.quantity,
                        total = orderDetail.total,
                    }
                ).Where(orderDetail => orderDetail.orderID == orderID).ToList();
            return list;
        }
    }
}
