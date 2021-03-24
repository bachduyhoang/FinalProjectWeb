using DAL.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            var user = context.Users.FirstOrDefault(x => x.userID == userID && x.password == password && x.status == true);
            return user;
        }

        public User checkInfo(string userID)
        {
            var userDetails = context.Users.Where(x => x.userID == userID).FirstOrDefault();
            return userDetails;
        }

        public User checkEmail(string email)
        {
            var emailDetails = context.Users.FirstOrDefault(x => x.email == email);
            return emailDetails;
        }

        public void register(string userID, string fullName, string email, string password)
        {
            object[] parameters =
            {
                new SqlParameter("@userID", userID),
                new SqlParameter("@fullName", fullName),
                new SqlParameter("@password", ""),
                new SqlParameter("@status", true),
                new SqlParameter("@dateCreated", DateTime.Now),
                new SqlParameter("@roleID", "us"),
                new SqlParameter("@email", email)
            };
            context.Database.ExecuteSqlCommand("Sp_User_Insert @userID,@fullName,@password,@status,@dateCreated,@roleID,@email", parameters);
            

            //User userModel = new User();
            //userModel.userID = userID;
            //userModel.fullName = fullName;
            //userModel.email = email;
            //userModel.password = password;
            //userModel.roleID = "us";
            //userModel.status = true;
            //userModel.dateCreated = DateTime.Now;
            //context.Users.Add(userModel);
            //context.SaveChanges();
        }
    }
}
