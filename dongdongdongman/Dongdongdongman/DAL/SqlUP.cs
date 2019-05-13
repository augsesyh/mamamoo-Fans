using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    class SqlUP:IUP
    {
        dongdongdongEntities db = new dongdongdongEntities();
        public UP FindAllUP(string account,string password)
        {
            UP uP = db.UP.Where(o => o.UP_account == account).Where(o => o.UP_password == password).FirstOrDefault();
            return uP;
        }

        public UP Findaccount(string account)
        {
            UP u = db.UP.Where(o => o.UP_account == account).FirstOrDefault();
            return u;
        }

        public int Add_User(string account,string upwd,int a)
        {
            UP up = new UP
            {
                UP_account = account,
                UP_password = upwd,
                UP_detail_id = a
            };
            db.UP.Add(up);
            return db.SaveChanges();
        }
        public UP FindUP(string email)
        {
            var de = db.User_detail.Where(o => o.User_email == email).FirstOrDefault();
            if(de==null)
            {
                return null;
            }
            else
            {
                var dt = de.UP.FirstOrDefault();
                return dt;
            }
        }
    }
}
