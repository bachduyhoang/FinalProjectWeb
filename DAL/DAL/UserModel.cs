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

        //public List<User> GetList(int currentPage, string SearchWord)
        //{
        //    int size = 5;
        //    var list = context.Users.OrderBy(x => x.userID).Where(x => x.userID.Contains(SearchWord)).Skip((currentPage - 1) * size).Take(size).ToList();
        //    return list;
        //}
        //public int CountPage(string SearchWord)
        //{
        //    int size = 5;
        //    int totalPage = 0;
        //    int totalRow = context.Users.Where(x => x.userID.Contains(SearchWord)).Count();
        //    if (totalRow % size > 0)
        //    {
        //        totalPage = totalRow / size + 1;
        //    }
        //    else
        //    {
        //        totalPage = totalRow / size;
        //    }
        //    return totalPage;
        //}

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
                user.email = u.email;
                context.SaveChanges();
                return true;
            }
            catch (Exception se)
            {
                return false;
            }
        }

        public void Delete(string id)
        {
            var user = context.Users.Find(id);
            if (user.status == true)
            {
                user.status = false;
            }
            else
            {
                user.status = true;
            }
            context.SaveChanges();
        }

        public User GetUser(string id, string password)
        {
            var user = context.Users.SingleOrDefault(x => x.userID == id && x.password == password && x.status == true);
            return user;
        }

        public User GetUserByEmail(string email)
        {
            var user = context.Users.SingleOrDefault(x => x.userID == email && x.status == true);
            return user;
        }
    }
}
