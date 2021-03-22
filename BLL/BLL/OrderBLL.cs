using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL
{
    public class OrderBLL
    {
        DBContext context = null;
        public OrderBLL()
        {
            context = new DBContext();
        }

        public List<Order> GetList(int currentPage, string SearchWord)
        {
            int PAGE_SIZE = 5;
            var list = context.Orders.OrderBy(x => x.orderID).Where(x => x.userID.Contains(SearchWord)).Skip((currentPage - 1) * PAGE_SIZE).Take(PAGE_SIZE).ToList();
            return list;
        }

        public int CountPage(string SearchWord)
        {
            int PAGE_SIZE = 5;
            int totalPage = 0;
            int totalRow = context.Orders.Where(x => x.userID.Contains(SearchWord)).Count();
            if (totalRow % PAGE_SIZE > 0)
            {
                totalPage = totalRow / PAGE_SIZE + 1;
            }
            else
            {
                totalPage = totalRow / PAGE_SIZE;
            }
            return totalPage;
        }

        public Order Find(int orderID)
        {
            var result = context.Orders.FirstOrDefault(x => x.orderID == orderID);
            return result;
        }

        public void Delete(int orderID)
        {
            var result = context.Orders.SingleOrDefault(x => x.orderID == orderID);
            
            if (result.status == true)
            {
                result.status = false;
            }
            else
            {
                result.status = true;
            }
            context.SaveChanges();
        }
    }
}
