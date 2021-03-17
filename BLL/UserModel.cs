using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAL;
using DAL.EF;

namespace BLL
{
    public class UserModel
    {
        AccountModel model = new AccountModel();
        public User checkUser(string userID, string password)
        {
            return model.checkUser(userID, password);
        }

        public User checkInfo(string userID)
        {
            return model.checkInfo(userID);
        }

        public User checkEmail(string email)
        {
            return model.checkEmail(email);
        }

        public void register(string userID, string fullName, string email, string password)
        {
            model.register(userID, fullName, email, password);
        }
    }
}
