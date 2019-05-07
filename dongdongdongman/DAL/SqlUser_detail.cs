using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    class SqlUser_detail : IUser_detail
    {
        dongdongdongEntities db = new dongdongdongEntities();
        User_detail IUser_detail.Findsame(string name)
        {
            var da =db.User_detail.Where(o=>o.User_name==name).FirstOrDefault();
            return da;
        }
       int IUser_detail.Add_detail(string name, string realname,string Email)
        {
            User_detail ud = new User_detail
            {
                User_name = name,
                User_realname = realname,
                User_email = Email
            };
            db.User_detail.Add(ud);
            db.SaveChanges();
            return ud.User_detail_id;
        }
        


    }
}
