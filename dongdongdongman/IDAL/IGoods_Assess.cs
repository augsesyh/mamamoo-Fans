using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IDAL
{
   public interface IGoods_Assess
    {
        IEnumerable<Goods_Assess> GetAllAssess();
        void Del_Assess(int gaid);
    }
}
