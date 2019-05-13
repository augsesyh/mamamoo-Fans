using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using DALFactory;
using IDAL;
namespace BLL
{
   public class GoodsManager
    {
        IGoods da = DataAccess.CreateGoods();
        public IQueryable<Goods> GetGoods()
        {
            return da.GetGoods();
        }
    }
}
