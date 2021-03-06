using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{

    public class ProductDAL
    {
        private static DBContext db = null;
        public ProductDAL()
        {
            db = new DBContext();
        }

        public List<Product> GetListNew()
        {
            return (List<Product>)db.Products.OrderByDescending(p => p.dayCreated).Skip(1).Take(2).ToList();
        }
        public List<Brand> GetListBrand()
        {
            return db.Brands.ToList();
        }

        public List<Product> GetListOfBrand(string brandName, ref int totalRecord, int index = 1, int maxPage = 20)
        {
            totalRecord = db.Products.Where(x => x.brandID.Contains(brandName)).Count();
            return db.Products.Where(x => x.brandID.Contains(brandName)).OrderBy(x => x.dayCreated).Skip((index - 1) * maxPage).Take(maxPage).ToList();
        }

        public List<Product> GetListAllProduct(string name, ref int totalRecord, int index = 1, int maxPage = 20)
        {
            totalRecord = db.Products.Where(x => x.productName.Contains(name)).Count();
            return db.Products.Where(x => x.productName.Contains(name)).OrderBy(x => x.quantity).Skip((index - 1) * maxPage).Take(maxPage).ToList();
        }
        public List<string> GetListAll(string name)
        {
            return db.Products.Where(x => x.productName.Contains(name)).Select(x =>x.productName).ToList();
        }
        public Product GetProduct(int id)
        {
            return db.Products.Find(id);
        }
        public int GetMaxQuantity(int id)
        {
            return (int)db.Products.Find(id).quantity;
        }

        public int InsertOrder(Order o )
        {
            db.Orders.Add(o);
            db.SaveChanges();
            return o.orderID;
        }

        public void InsertOrderDetail(OrderDetail orderDetail)
        {
            db.OrderDetails.Add(orderDetail);
            var product = db.Products.Find(orderDetail.productID);
            var quantity = product.quantity - orderDetail.quantity;
            product.quantity = quantity;
            db.SaveChanges();
        }
    }
}
