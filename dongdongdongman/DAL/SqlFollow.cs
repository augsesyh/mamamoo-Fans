using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;
namespace DAL
{
    public class SqlFollow : IFollow
    {
        dongdongdongEntities db = new dongdongdongEntities();
        public void Add_Follow(int Comic_id,int User_id)
        {
            Follow fl =new Follow();
            fl.Comic_id = Comic_id;
            fl.Follow_time = DateTime.Now;
            fl.User_id = User_id;
            db.Follow.Add(fl);
            db.SaveChanges();
        }

        public void Del_Follow(int Comic_id, int User_id)
        {
            var da = db.Follow.Where(o=>o.Comic_id==Comic_id).Where(c=>c.User_id==User_id).FirstOrDefault();
            db.Follow.Remove(da);
            db.SaveChanges();
        }
    }
}
