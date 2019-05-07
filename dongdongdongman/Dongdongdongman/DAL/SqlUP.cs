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
    }
}
