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
            var da = Session["User_name"].ToString();
            Comic_detail h = new Comic_detail(c.Comic_id,da ,1);
            return PartialView("Comment", h); ;
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
            return View();
        }
        [HttpPost]
        public ActionResult Add_Comment1(string recontent,string reback_id, string uid, string cid,string reb1)
        {
            ReBack re = new ReBack();
            re.Comment_id = Convert.ToInt32(reback_id);
            if (reb1 == null)
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
            int cid1 = Convert.ToInt32(cid);
           var da = Session["User_name"].ToString();
            Comic_detail h = new Comic_detail(cid1, da, 1);
            return PartialView("Comment", h);
        }
    }
}