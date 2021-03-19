using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL
{
    public class DiscountCodeBLL
    {
        DBContext context = null;
        public DiscountCodeBLL()
        {
            context = new DBContext();
        }

        public List<Discount> GetList(int currentPage, string searchWord)
        {
            int PAGE_SIZE = 5;
            var list = context.Discounts.OrderBy(x => x.discountID).Where(x => x.discountID.Contains(searchWord)).Skip((currentPage - 1) * PAGE_SIZE).Take(PAGE_SIZE).ToList();
            return list;
        }

        public int CountPage(string searchWord)
        {
            int PAGE_SIZE = 5;
            int totalPage = 0;
            int totalRow = context.Discounts.Where(x => x.discountID.Contains(searchWord)).Count();
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

        public int CheckIdExisted(string DiscountID)
        {
            var result = context.Discounts.Where(x => x.discountID == DiscountID).Count();
            return result;
        }

        public Discount Find(string DiscountID)
        {
            Discount dis = context.Discounts.Find(DiscountID);
            return dis;
        }

        public void Insert(Discount discount)
        {
            discount.dayCreated = DateTime.Now;
            context.Discounts.Add(discount);
            context.SaveChanges();
        }

        public void Delete(string discountID)
        {
            var dis = new Discount { discountID = discountID};
            context.Entry(dis).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(Discount dis)
        {
            var result = context.Discounts.SingleOrDefault(x => x.discountID == dis.discountID);
            if(result != null)
            {
                result.discountPercent = dis.discountPercent;
                result.expiry = dis.expiry;
                context.SaveChanges();
            }
        }
    }
}
