﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAL;
using DAL.EF;

namespace BLL
{
    public class UserBLL
    {
        UserModel model = new UserModel();
        public IEnumerable<User> GetListPaging(string txtSearch, int page, int size)
        {
            return model.GetListPaging(txtSearch, page, size);
        }

        public User GetUserByID(string id)
        {
            return model.GetUserById(id);
        }

        public bool UpdateUser(User u)
        {
            return model.Update(u);
        }

        public bool DeleteUser(string id)
        {
            return model.Delete(id);
        }
    }
}
