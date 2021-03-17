using DAL;
using DAL.DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductBLL
    {
        private ProductDAL p = null;

        public ProductBLL()
        {
            p = new ProductDAL();
        }
        public List<Product>GetListNew()
        {
            return p.GetListNew();
        }

        public List<Brand> GetListBrand()
        {
            return p.GetListBrand();
        }

        public List<Product> GetListOfBrand(string brandName,ref int totalRecord, int index = 1, int maxPage = 5)
        {
            return p.GetListOfBrand(brandName,ref totalRecord ,index, maxPage);
        }

        public Product GetProduct(int id)
        {
            return p.GetProduct(id);
        }
    }
}
