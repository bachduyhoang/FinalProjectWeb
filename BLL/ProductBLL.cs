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
        ProductModel model = new ProductModel();
        private ProductDAL p = null;

        public ProductBLL()
        {
            p = new ProductDAL();
        }
        public List<Product> GetListNew()
        {
            return p.GetListNew();
        }

        public List<Brand> GetListBrand()
        {
            return p.GetListBrand();
        }

        public List<Product> GetListOfBrand(string brandName, ref int totalRecord, int index = 1, int maxPage = 20)
        {
            return p.GetListOfBrand(brandName, ref totalRecord, index, maxPage);
        }

        public Product GetProduct(int id)
        {
            return p.GetProduct(id);
        }

        public List<Product> GetListAllProduct(string name, ref int totalRecord, int index = 1, int maxPage = 20)
        {
            return p.GetListAllProduct(name, ref totalRecord, index, maxPage);
        }

        public int GetMaxQuantity(int id)
        {
            return p.GetMaxQuantity(id);
        }

        public int InsertOrder(Order o)
        {
            return p.InsertOrder(o);
        }

        public void InsertOrderDetail(OrderDetail detail)
        {
            p.InsertOrderDetail(detail);
        }

        public IEnumerable<Product> GetListPaging(string txtSearch, int page, int size)
        {
            return model.GetListPaging(txtSearch, page, size);
        }

        public List<Brand> GetListBrandThy()
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
