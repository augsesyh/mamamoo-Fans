using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
   public class Sqladmin : IAdmin
    {
        dongdongdongEntities db = new dongdongdongEntities();

        public admin FindBynaal(string name)
        {
           var da = db.admin.Where(c=>c.admin_access==name).FirstOrDefault();
            return da;
        }

        admin IAdmin.FindByname(string name, string pwd)
        {
            var da=db.admin.Where(o=>o.admin_access==name).Where(c=>c.admin_password==pwd).FirstOrDefault();
            return da;
        }
    }
}
