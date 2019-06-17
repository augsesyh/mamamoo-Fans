using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IDAL
{
    public interface IShoppingCart
    {
        IEnumerable<ShoppingCart> FindshoppingCarts(int uid);
        void low_ShoppingCart(int sid);
        void Add_ShoppingCart(int sid);
    }
}
