using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;
namespace DAL
{
    public class SqlGoods : IGoods
    {
        dongdongdongEntities db = new dongdongdongEntities();
        IQueryable<Goods> IGoods.GetGoods()
        {
            var da = db.Goods.OrderBy(o=>o.Goods_id).Take(9);
            return da;
        }
    }
}
