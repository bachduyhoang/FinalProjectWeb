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

        public List<Product> GetListOfBrand(string brandName, ref int totalRecord, int index = 1, int maxPage = 5)
        {
            totalRecord = db.Products.Where(x => x.brandID.Contains(brandName)).Count();
            return db.Products.Where(x => x.brandID.Contains(brandName)).OrderBy(x => x.dayCreated).Skip((index - 1) * maxPage).Take(maxPage).ToList();
        }

        public Product GetProduct(int id)
        {
            return db.Products.Find(id);
        }
    }
}
