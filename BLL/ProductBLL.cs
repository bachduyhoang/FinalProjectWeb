using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAL;
using DAL.EF;

namespace BLL
{
    public class ProductBLL
    {
        ProductModel model = new ProductModel();
        public IEnumerable<Product> GetListPaging(string txtSearch, int page, int size)
        {
            return model.GetListPaging(txtSearch, page, size);
        }

        public List<Brand> GetListBrand()
        {
            return model.GetListBrand();
        }

        public List<Product> GetListAll()
        {
            return model.GetListAll();
        }

        public int Create(Product p)
        {
            return model.Create(p);
        }

        public void ActivityLog(int idProduct)
        {
            model.InsertActivity(idProduct);
        }
        public int GetIdProduct()
        {
            return model.GetIDProduct();
        }

        public Product GetProductById(int id)
        {
            return model.GetProductByID(id);
        }
        public bool checkInteger(string input)
        {
            return model.checkInteger(input);
        }

        public bool UpdateProduct(Product p)
        {
            return model.Update(p);
        }

        public bool DeleteProduct(int id)
        {
            return model.Delete(id);
        }


    }
}
