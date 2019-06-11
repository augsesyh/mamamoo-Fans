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
        public void Add_Goods(string name, int price, int nums, string photo, string intro, int Goods_Cate,string text)
        {
            da.Add_Goods(name, price, nums, photo, intro, Goods_Cate,text);
        }
        public IEnumerable<Goods> GetAllGood()
        {
            return da.GetAllGood();
        }
        public void Detele_Goods(int id)
        {
            da.Detele_Goods(id);
        }
        public Goods FindByid(int Gid)
        {
            return da.FindByid(Gid);
        }
        public IEnumerable<Goods> FindBystr(string shoushuo)
        {
            return da.FindBystr(shoushuo); 
        }
    }
}