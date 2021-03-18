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
    public class UserModel
    {
        DBContext context = null;
        string strConnection = @"server=SE140695\SQLEXPRESS;database=ProjectTGDD;uid=sa;pwd=123";

        public UserModel()
        {
            context = new DBContext();
        }

        public IEnumerable<User> GetListPaging(string txtSearch, int page, int size)
        {
            IQueryable<User> model = context.Users;
            if (!string.IsNullOrEmpty(txtSearch))
            {
                model = model.Where(x => x.fullName.Contains(txtSearch) && x.roleID != "ad");
            }
            return model.Where(x => x.roleID != "ad").OrderByDescending(x => x.dateCreated).ToPagedList(page, size);
        }

        public User GetUserById(string id)
        {
            return context.Users.Find(id);
        }

        public bool Update(User u)
        {
            try
            {
                var user = GetUserById(u.userID);
                user.fullName = u.fullName;
                user.password = u.password;
                user.status = u.status;
                context.SaveChanges();
                return true;
            }
            catch (Exception se)
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                bool check;
                SqlConnection cnn = new SqlConnection(strConnection);
                string SQL = "update Users " +
                            "set status = 0 " +
                            "where userID = @ID";
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
