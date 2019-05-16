using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;
namespace DAL
{
    class SqlVideo : IVideo
    {
        dongdongdongEntities db = new dongdongdongEntities();
        public IQueryable<Video> GetNew()
        {
            var da = db.Video.OrderBy(o=>o.Video_nums).Take(9);
            return da;
        }
    }
}
