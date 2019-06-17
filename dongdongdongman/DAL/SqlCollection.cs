using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;
namespace DAL
{
    class SqlCollection : ICollection
    {
        dongdongdongEntities db = new dongdongdongEntities();

        public void Del_Collection(int cid)
        {
          var da = db.Collection.Where(o=>o.Collection_id==cid).FirstOrDefault();
            db.Collection.Remove(da);
            db.SaveChanges();
        }

        public IQueryable<Collection> FindByuid(int uid)
        {
            return db.Collection.Where(o=>o.User_id==uid);
        }
    }
}
