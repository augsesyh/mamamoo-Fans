using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Dongdongdongman.Models;
namespace Dongdongdongman.Controllers
{
    public class ComicController : Controller
    {
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
                return PartialView("Comment1",h);
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
        public ActionResult Pay()
        {
            return View();
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
    }
}