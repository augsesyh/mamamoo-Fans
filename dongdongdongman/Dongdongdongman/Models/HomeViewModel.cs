using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using BLL;
namespace Dongdongdongman.Models
{
    public class HomeViewModel
    {
        GoodsManager gm = new GoodsManager();
        VideoManager vm = new BLL.VideoManager();
        ComicManager cm = new ComicManager();
        public IEnumerable<Comic> Nc;
        public IEnumerable<Comic> Te;
        public IEnumerable<Comic_chapter> uc;
        public IQueryable<Video> vo;
        public IQueryable<Goods> ig;
        public HomeViewModel()
        {
            ig = gm.GetGoods();
            vo = vm.GetNew();
            uc = cm.UP_New();
            Nc = cm.NewComics();
            Te = cm.TopEight();
        }
    }
}