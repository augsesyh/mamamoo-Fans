using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Dongdongdongman.Models;
using BLL;
namespace Dongdongdongman.Controllers
{
    public class ComicController : Controller
    {
        ComicManager cm = new ComicManager();
        dongdongdongEntities db = new dongdongdongEntities();
        // GET: Comic
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(int cid,int coid=1)
        {
            ViewBag.co = coid;
            var da = Session["User_name"].ToString();
            Comic_detail h = new Comic_detail(cid,da,coid);
            if (Request.IsAjaxRequest())
                return PartialView("Comment",h);
            return View(h);
        }
        [HttpPost]
        public ActionResult Add_Comment(string uid,string cid,string Comment_con,string coid)
        {
          
            Comment c = new Comment();
            c.User_id = Convert.ToInt32(uid);
            c.Comment_time = DateTime.Now;
            c.Comment_intro = Comment_con;
            c.Comic_id = Convert.ToInt32(cid);
            db.Comment.Add(c);
            db.SaveChanges();
            return RedirectToAction("Detail", new { cid = c.Comic_id, coid = 1 });
        }
        public ActionResult ALl_More()
        {
            var da = db.Comic;
            return View(da);
        }
        public ActionResult Pay(string ccid)
        {

            var ci = Convert.ToInt32(ccid);
            Comic_chapterManager cm = new Comic_chapterManager();
            var c = cm.FindByid(ci);
            var cd = c.Comic.Comic_chapter.Where(o => o.Comic_fufei == 1).Count();
            ViewBag.id = cd;
            return View(c);
        }
        public ActionResult Fenlei()
        {
            Comic_Fenlei Cf = new Comic_Fenlei();
            return View(Cf);
        }
        [HttpPost]
        public ActionResult Add_Comment1(string recontent,string reback_id, string uid, string cid1,string reb1,string coid1)
        {
            ReBack re = new ReBack();
            re.Comment_id = Convert.ToInt32(reback_id);
            if (reb1 == ""|| reb1==null)
            {
                re.Reback1_id = null;
            }
            else
            {
                re.Reback1_id = Convert.ToInt32(reb1);
            }
            re.ReBack_intro = recontent;
            re.ReBack_time = DateTime.Now;
            re.User_id = Convert.ToInt32(uid);
            db.ReBack.Add(re);
            db.SaveChanges();
            var cid2 = Convert.ToInt32(cid1);
            var coid3 = Convert.ToInt32(coid1);
            return RedirectToAction("Detail", new { cid = cid2, coid = coid1 });
        }
        public PartialViewResult FenleiPart(string[] List)
        {

            Comic_Fenlei cf = new Comic_Fenlei(List);
            
            //if(List[0]!="全部")
            //{
            //    cf.cm = cf.cm.Where(o => o.Audiences == List[0]);
            //}
            //if (List[1] != "全部")
            //{
            //    cf.cm = cf.cm.Where(o => o.Audiences == List[1]);
            //}
            //if (List[2] != "全部")
            //{
            //    cf.cm = cf.cm.Where(o => o.Contents == List[2]);
            //}
            //if (List[3] != "全部")
            //{
            //    cf.cm = cf.cm.Where(o => o.Territory == List[3]);
            //}
            //if (List[4] != "全部")
            //{
            //    cf.cm = cf.cm.Where(o => o.Forms == List[4]);
            //}
            return PartialView(cf);
        }
        public ActionResult Comic_pager(int cid,int nums=1)
        {
            
            Comic_pagerMananger ccm = new Comic_pagerMananger();
           var da = ccm.FindBynums(cid,nums);
            var dc =da.Comic_chapter.Comic_chapter_num + 1;
            
                var dt = da.Comic_chapter.Comic.Comic_chapter.Where(o => o.Comic_chapter_num == dc).FirstOrDefault();
             if(dt!=null)
            {
                ViewBag.nexcd = dt.Comic_chapter_id;
            }
            
            
            var dp = da.Comic_chapter.Comic_chapter_num - 1;
           
                var dt1 = da.Comic_chapter.Comic.Comic_chapter.Where(c => c.Comic_chapter_num == dp).FirstOrDefault();
            if (dt1 != null)
            {
                ViewBag.precd = dt1.Comic_chapter_id;
            }
            
 
            ViewBag.num = nums;
            return View(da);
        }
        public ActionResult AddSubscribe(string ccid)
        {
            
            var cci = Convert.ToInt32(ccid);
            Comic_chapterManager cm = new Comic_chapterManager();
            var c = cm.FindByid(cci);
            var ui = Convert.ToInt32(Session["User_id"].ToString());
            SubscribeManager sm = new SubscribeManager();
            sm.AddSubscribe(cci, ui);
            return RedirectToAction("Detail","Comic",new { cid=c.Comic_id });
        }
        public ActionResult Add_Comic(int coid)
        {
            var da = cm.FindComic(coid);
            int ccid = da.Comic_chapter.Where(o => o.Comic_chapter_num == 1).FirstOrDefault().Comic_chapter_id;
            int uid = Convert.ToInt32(Session["User_id"].ToString());
            SubscribeManager sm = new SubscribeManager();
            sm.Add_Comic(coid, uid);
            return RedirectToAction("Comic_pager", "Comic", new { cid = ccid });
        }
        [HttpPost]
          public ActionResult Comment_jubao(string leibie,string miaoshu,string jb,int cid)
        {
            int uid = Convert.ToInt32(Session["User_id"].ToString());
            ReportManager rp = new ReportManager();
            rp.Add_Report(leibie, miaoshu, jb, uid);
            return RedirectToAction("Detail",cid);
        }
        public ActionResult Add_Follow()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Add_Follow1(int Comic_id)
        {
            int User_id = Convert.ToInt32(Session["User_id"].ToString());
            FollowManager fm = new FollowManager();
            fm.Add_Follow(Comic_id, User_id);
            var da = Session["User_name"].ToString();
            Comic_detail cd = new Comic_detail(Comic_id,da,1);

            return PartialView("Add_Follow",cd);
        }

        [HttpPost]
        public ActionResult Del_Follow1(int Comic_id)
        {
            int User_id = Convert.ToInt32(Session["User_id"].ToString());
            FollowManager fm = new FollowManager();
            fm.Del_Follow(Comic_id, User_id);
            var da = Session["User_name"].ToString();
            Comic_detail cd = new Comic_detail(Comic_id, da, 1);

            return PartialView("Add_Follow",cd);
        }
        //[HttpPost]
        //public ActionResult Add_Follow(int Comic_id)
        //{

        //}
    }
}