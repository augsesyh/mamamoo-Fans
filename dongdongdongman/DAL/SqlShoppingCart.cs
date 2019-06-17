using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
    class SqlShoppingCart : IShoppingCart
    {
        dongdongdongEntities db = new dongdongdongEntities();
        public IEnumerable<ShoppingCart> FindshoppingCarts(int uid)
        {
           var a = db.ShoppingCart.Where(o=>o.User_id==uid);
            return a;
        }

        public void low_ShoppingCart(int sid)
        {
            var da = db.ShoppingCart.Where(o=>o.Cart_id==sid).FirstOrDefault();
            da.Goods_num = da.Goods_num - 1;
            db.SaveChanges();

        }
        public void Add_ShoppingCart(int sid)
        {
            var da = db.ShoppingCart.Where(o => o.Cart_id == sid).FirstOrDefault();
            da.Goods_num = da.Goods_num + 1;
            db.SaveChanges();

        }
    }
}
