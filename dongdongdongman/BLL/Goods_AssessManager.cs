using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using DALFactory;
namespace BLL
{
    public class Goods_AssessManager
    {
        IGoods_Assess a = DataAccess.CreateGoods_Assess();
        public IEnumerable<Goods_Assess> GetALLAssess()
        {
            return a.GetAllAssess();
        }
        public void Del_Assess(int gaid)
        {
            a.Del_Assess(gaid);
        }
    }
}
