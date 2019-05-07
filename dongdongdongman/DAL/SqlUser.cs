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

        public void Add_User(string account, string upwd,int a)
        {
            User u = new User
            {
                User_account = account,
                User_password=upwd,
                User_detail_id=a
            };
            db.User.Add(u);
            db.SaveChanges();
        }

        public User FindUser(string Email)
        {
           var da = db.User_detail.Where(o=>o.User_email==Email).FirstOrDefault();
            if (da == null)
            {
                return null;
            }
            else
            {

                var dt = da.User.FirstOrDefault();
                return dt;
            }
        }
        public User Findpassword(string account)
        {
            var da = db.User.Where(o => o.User_account == account).FirstOrDefault();
            return da;
        }
        public void Changepwd(string pwd,string account)
        {
            var da = db.User.Where(o => o.User_account == account).FirstOrDefault();
            da.User_password = pwd;
            db.SaveChanges();

        }
    }
    
}
