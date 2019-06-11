using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
namespace DAL
{
    public class SqlComic : IComic
    {
        dongdongdongEntities db = new dongdongdongEntities();
        public IQueryable<Comic> NewComics()
        {
            var da = db.Comic.OrderBy(o=>o.Comic_time).Take(8);
            return da;
        }

        public IQueryable<Comic> TopEight()
        {
            var da = db.Comic.OrderBy(o=>o.Follow_nums).Take(8);
            return da;
        }

        public IQueryable<Comic_chapter> Up_new()
        {
            var da = db.Comic_chapter.OrderBy(o => o.Comic_update_time).Take(8);
            return da;
        }
        public Comic FindComic(int id)
        {
            var da = db.Comic.Where(o => o.Comic_id == id).FirstOrDefault();
            return da;
        }

        public IQueryable<Comic> FindTop(int nums)
        {
            var da = db.Comic.OrderBy(o=>o.Follow_nums).Take(nums);
            return da;
        }

        public void Del_Comic(int Comic_id)
        {
            var da = db.Comic.Where(o=>o.Comic_id==Comic_id).FirstOrDefault();
            db.Comic.Remove(da);
            db.SaveChanges();
        }

        public IQueryable<Comic> GetComicByname(string name)
        {
            return db.Comic.Where(o=>o.Comic_name.IndexOf(name)>=0);
        }
    }
}
