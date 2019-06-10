using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using BLL;
using Webdiyer.WebControls.Mvc;
namespace Dongdongdongman.Models
{
    public class Admin_Index
    {
        GoodsManager gm = new GoodsManager();
       public IPagedList<Goods> g;
        
        public Admin_Index(int Gid)
        {
            g = gm.GetAllGood().OrderByDescending(o => o.Goods_id).ToPagedList(Gid, 10);  
        }
    }
}