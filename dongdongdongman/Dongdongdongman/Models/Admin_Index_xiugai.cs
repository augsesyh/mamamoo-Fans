using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using BLL;
namespace Dongdongdongman.Models
{
    public class Admin_Index_xiugai
    {
        Good_CateManager gcm = new Good_CateManager();
        GoodsManager gm = new GoodsManager();
        public IEnumerable<Goods_Cate> gc;
       public Goods good;
        public Admin_Index_xiugai(int good_id)
        {
            good = gm.FindByid(good_id);
            gc = gcm.FindALLGoodCate();
        }
    }
}