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

        public void Add_Goods(string name, int price, int nums, string photo, string intro,int Goods_Cate,string text)
        {
            Goods gds = new Goods();
            gds.Goods_cate = Goods_Cate;
            gds.Goods_intro = intro;
            gds.Goods_name = name;
            gds.Goods_nums = nums;
            gds.Goods_photo = photo;
            gds.Goods_price = price;
            gds.Good_intro_text = text;
            db.Goods.Add(gds);
            db.SaveChanges();
        }

        public void Detele_Goods(int id)
        {
            var da = db.Goods.Where(o=>o.Goods_id==id).FirstOrDefault();
            db.Goods.Remove(da);
            db.SaveChanges();
        }

        public Goods FindByid(int Goods_id)
        {
            return db.Goods.Where(o => o.Goods_id == Goods_id).FirstOrDefault();
        }

        public IEnumerable<Goods> FindBystr(string shoushuo)
        {
            return db.Goods.Where(o=>o.Goods_name.IndexOf(shoushuo)>=0);
        }

        public IEnumerable<Goods> GetAllGood()
        {
            return db.Goods;
        }

        IQueryable<Goods> IGoods.GetGoods()
        {
            var da = db.Goods.OrderBy(o=>o.Goods_id).Take(9);
            return da;
        }

    }
}
