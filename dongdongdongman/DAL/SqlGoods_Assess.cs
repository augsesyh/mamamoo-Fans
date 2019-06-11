using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
namespace DAL
{
    class SqlGoods_Assess : IGoods_Assess
    {
        dongdongdongEntities db = new dongdongdongEntities();

        public void Del_Assess(int gaid)
        {
            var ad = db.Goods_Assess.Where(o=>o.Assess_id==gaid).FirstOrDefault();
            db.Goods_Assess.Remove(ad);
            db.SaveChanges();
        }

        public IEnumerable<Goods_Assess> GetAllAssess()
        {
            return db.Goods_Assess;
        }
    }
}
