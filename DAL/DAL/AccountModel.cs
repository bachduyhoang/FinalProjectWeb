using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountModel
    {
        DBContext context = null;

        public AccountModel()
        {
            context = new DBContext();
        }

        public User checkUser(string userID, string password)
        {
            var user = context.Users.Where(x => x.userID == userID && x.password == password && x.status == true).Single();
            return user;
        }

        public User checkInfo(string userID)
        {
            var userDetails = context.Users.Where(x => x.userID == userID).FirstOrDefault();
            return userDetails;
        }

        public User checkEmail(string email)
        {
            var emailDetails = context.Users.Where(x => x.email == email).FirstOrDefault();
            return emailDetails;
        }

        public void register(string userID, string fullName, string email, string password)
        {
            User userModel = new User();
            userModel.userID = userID;
            userModel.fullName = fullName;
            userModel.email = email;
            userModel.password = password;
            userModel.roleID = "us";
            userModel.status = true;
            userModel.dateCreated = DateTime.Now;
            context.Users.Add(userModel);
            context.SaveChanges();
        }
    }
}
