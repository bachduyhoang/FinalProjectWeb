using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;

namespace DAL.DAL
{
    public class UserModel
    {
        DBContext context = null;


        public UserModel()
        {
            context = new DBContext();
        }

        public List<User> GetListPagingByHand(string txtSearch, ref int totalPage, int index=1, int size = 20)
        {
            List<User> list = new List<User>();
            if (string.IsNullOrEmpty(txtSearch))
            {
                txtSearch = "";
            }
            totalPage = user.Count;
            if ((totalPage % 20) != 0)
            {
                totalPage++;
            }
            list = context.Users.OrderBy(x => x.dateCreated).Skip((index - 1) * size).Take(size).ToList();

            return list;
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
            user.status = false;
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

        public List<string> Paging(int index, int max)
        {
            int current = index,
                last = max,
                delta = 5,
                left = current - delta,
                right = current + delta + 1 ;

            List<string> range = new List<string>() ;

            if (current <= (delta + 1))
            {
                for (var i = 2; i <= last; i++)
                {
                    if (i < (delta * 2 + 1))
                    {
                        range.Add(i.ToString());
                    }
                }
                range.Add("...");
            }
            else if (current >= (last - delta))
            {
                range.Add("...");
                for (var i = 2; i <= last; i++)
                {
                    if (i < last && i > last - 2 * delta)
                    {
                        range.Add(i.ToString());
                    }
                }
            }
            else
            {
                range.Add("...");
                for (var i = 2; i <= last; i++)
                {
                    if (i > left && i < right)
                    {
                        range.Add(i.ToString());
                    }
                }
                range.Add("...");
            }

            return range;
        }
    }
}
