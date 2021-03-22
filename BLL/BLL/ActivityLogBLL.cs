using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BLL
{
    public class ActivityLogBLL
    {
        DBContext context = null;
        public ActivityLogBLL()
        {
            context = new DBContext();
        }

        public List<ActivityLog> GetList(int currentPage, string SearchWord)
        {
            int PAGE_SIZE = 5;
            var list = context.ActivityLogs.OrderBy(x => x.activityLogID).Where(x => x.userID.Contains(SearchWord)).Skip((currentPage - 1) * PAGE_SIZE).Take(PAGE_SIZE).ToList();
            return list;
        }

        public int CountPage(string SearchWord)
        {
            int PAGE_SIZE = 5;
            int totalPage = 0;
            int totalRow = context.ActivityLogs.Where(x => x.userID.Contains(SearchWord)).Count();
            if (totalRow % PAGE_SIZE > 0)
            {
                totalPage = totalRow / PAGE_SIZE + 1;
            }
            else
            {
                totalPage = totalRow / PAGE_SIZE;
            }
            return totalPage;
        }
    }
}
