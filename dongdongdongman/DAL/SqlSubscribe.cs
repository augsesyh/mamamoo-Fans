using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;
namespace DAL
{
    public class SqlSubscribe : ISubscribe
    {
        dongdongdongEntities db = new dongdongdongEntities();
        IEnumerable<Subscribe> ISubscribe.Findsu(int uid)
        {
            var da = db.Subscribe.Where(o=>o.User_id==uid);
            return da;
        }
        void ISubscribe.AddSubscribe(int ccid,int uid)
        {
            var da = db.Comic_chapter.Where(o => o.Comic_chapter_id == ccid).FirstOrDefault();
            Subscribe su = new Subscribe();
            su.Comic_detail_id = ccid;
            su.Subscribe_price = 10;
            su.Subscribe_time = DateTime.Now;

            su.User_id = uid;
            su.Subscribe_nums = 1;
            db.Subscribe.Add(su);
            db.SaveChanges();
        }
    }
}
