using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IDAL
{
    public interface IGoods
    {
        IQueryable<Goods> GetGoods();
        void Add_Goods(string name, int price, int nums, string photo, string intro,int Good_Cate,string text);
        IEnumerable<Goods> GetAllGood();
        void Detele_Goods(int id);
        Goods FindByid(int Goods_id);
        IEnumerable<Goods> FindBystr(string shoushuo);
    }
}
