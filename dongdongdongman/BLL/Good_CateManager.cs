using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using DAL;
using DALFactory;
namespace BLL
{
   public class Good_CateManager
    {
        IGood_Cate gc = DataAccess.CreateGood_Cate();
        public IEnumerable<Goods_Cate> FindALLGoodCate()
        {
            return gc.FindAllGood_Cate();
        }
        public void Add_Cate(string name)
        {
            gc.Add_Cate(name);
        }
    }
}
