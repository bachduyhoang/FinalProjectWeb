using System;
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
        //public IEnumerable<User> GetListPaging(string txtSearch, int page, int size)
        //{
        //    return model.GetListPaging(txtSearch, page, size);
        //}
        //public List<User> GetList(int currentPage, string SearchWord)
        //{
        //    return model.GetList(currentPage, SearchWord);
        //}

        //public int CountPage(string SearchWord)
        //{
        //    return model.CountPage(SearchWord);
        //}

        public User GetUserByID(string id)
        {
            return model.GetUserById(id);
        }

        public bool UpdateUser(User u)
        {
            return model.Update(u);
        }

        public void DeleteUser(string id)
        {
            model.Delete(id);
        }
        public User GetUser(string id, string password)
        {
            return model.GetUser(id, password);
        }

        public List<User> GetListPagingHand(string txtSearch, ref int totalPage, int index)
        {
            return model.GetListPagingByHand(txtSearch, ref totalPage, index);
        }

        public List<string> Paging(int index, int max)
        {
            return model.Paging(index, max);
        }
    }
}