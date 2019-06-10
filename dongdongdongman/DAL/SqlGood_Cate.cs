using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    public class SqlGood_Cate : IGood_Cate
    {
        dongdongdongEntities db = new dongdongdongEntities();

        public void Add_Cate(string name)
        {
            Goods_Cate gc = new Goods_Cate();
            gc.Goods_Cate_name = name;
            db.Goods_Cate.Add(gc);
            db.SaveChanges();
        }

        public IEnumerable<Goods_Cate> FindAllGood_Cate()
        {
            return db.Goods_Cate;
        }
    }
}
