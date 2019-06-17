using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using IDAL;
using DALFactory;
using Models;
namespace BLL
{
    public class ShoppingCartManager : IShoppingCart
    {
        IShoppingCart sc = DataAccess.CreateShoppingCart();

        public void Add_ShoppingCart(int sid)
        {
            sc.Add_ShoppingCart(sid);
        }

        public IEnumerable<ShoppingCart> FindshoppingCarts(int uid)
        {
            return sc.FindshoppingCarts(uid);
        }

        public void low_ShoppingCart(int sid)
        {
            sc.low_ShoppingCart(sid);
        }
    }
}
