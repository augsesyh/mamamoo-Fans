using IDAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SqlUser : IUser
    {
        dongdongdongEntities db = new dongdongdongEntities();
        public User FindUser(string name,string password)
        {
            User a = db.User.Where(o=>o.User_account==name).Where(c=>c.User_password==password).FirstOrDefault();
            return a;
        }
        public User Findaccount(string account)
        {
            User b = db.User.Where(o => o.User_account == account).FirstOrDefault();
            return b;
        }
    }
}
