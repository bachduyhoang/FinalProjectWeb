using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using PagedList;

namespace DAL.DAL
{
    public class ProductModel
    {
        DBContext context = null;
        string strConnection = @"server=SE140695\SQLEXPRESS;database=ProjectTGDD;uid=sa;pwd=123";

        public ProductModel()
        {
            context = new DBContext();
        }

        public IEnumerable<Product> GetListPaging(string txtSearch, int page, int size)
        {
            IQueryable<Product> model = context.Products;
            if (!string.IsNullOrEmpty(txtSearch))
            {
                model = model.Where(x => x.productName.Contains(txtSearch));
            }
            return model.OrderByDescending(x => x.dayCreated).ToPagedList(page, size);
        }

        public int Create(Product p)
        {
            object[] parameters =
            {
                new SqlParameter("@Name", p.productName),
                new SqlParameter("@Image", p.imageLink),
                new SqlParameter("@Price", p.price),
                new SqlParameter("@Quantity", p.quantity),
                new SqlParameter("@Description", p.description),
                new SqlParameter("@Status", true),
                new SqlParameter("@BrandID", p.brandID)
            };
            int res = context.Database.ExecuteSqlCommand("Sp_Product_Insert @Name,@Image,@Price,@Quantity,@Description,@Status,@BrandID", parameters);
            return res;
        }

        public void InsertActivity(int ProductID)
        {
            object[] parameters =
            {
                new SqlParameter("@User", "admin"),
                new SqlParameter("@ProductID", ProductID)
            };
            context.Database.ExecuteSqlCommand("Sp_Activity_Insert @User,@ProductID", parameters);
        }

        public List<Product> GetListAll()
        {
            var list = context.Database.SqlQuery<Product>("Sp_Product_listAll").ToList();
            return list;
        }

        public bool Update(Product p)
        {
            try
            {
                var product = GetProductByID(p.productID);
                product.productName = p.productName;
                product.imageLink = p.imageLink;
                product.price = p.price;
                product.quantity = p.quantity;
                product.description = p.description;
                product.status = p.status;
                product.brandID = p.brandID;
                context.SaveChanges();
                return true;
            }
            catch (Exception se)
            {
                return false;
            }
        }

        public Product GetProductByID(int id)
        {
            return context.Products.Find(id);
        }

        public int GetIDProduct()
        {
            int result = 0;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "select top 1 productID " +
                           "from Products " +
                           "order by productID desc";
            SqlCommand cmd = new SqlCommand(SQL, cnn);

            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = int.Parse(reader[0].ToString());
                }

            }
            catch (Exception se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                cnn.Close();
            }

            return result;
        }

        public bool Delete(int id)
        {
            try
            {
                bool check;
                SqlConnection cnn = new SqlConnection(strConnection);
                string SQL = "update Products " +
                            "set status = 0 " +
                            "where productID = @ID";
                SqlCommand cmd = new SqlCommand(SQL, cnn);
                cmd.Parameters.AddWithValue("@ID", id);
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                check = cmd.ExecuteNonQuery() > 0;
                return check;
            }
            catch (Exception se)
            {
                return false;
            }
        }
    }
}
