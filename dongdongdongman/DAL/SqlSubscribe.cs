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

        public void Add_Comic(int coid,int uid)
        {
            List<Subscribe> ac=new List<Subscribe>();
            var da = db.Comic_chapter.Where(o=>o.Comic_id==coid).Where(c=>c.Comic_fufei==1);
            foreach(var it in da)
            {
                Subscribe sb = new Subscribe();
                sb.Comic_detail_id = it.Comic_chapter_id;
                sb.Subscribe_nums = 1;
                sb.Subscribe_price = 10;
                sb.Subscribe_time = DateTime.Now;
                sb.User_id = uid;
                ac.Add(sb);
            }
            db.Subscribe.AddRange(ac);
            db.SaveChanges();
        }
    }
}
