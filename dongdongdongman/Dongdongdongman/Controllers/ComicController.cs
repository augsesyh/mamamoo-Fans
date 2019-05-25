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
            if(Comment_con.Trim()=="")
            {
                return Content("alert('评论内容不能为空');", "text/javascript");
            }
            Comment c = new Comment();
            c.User_id = Convert.ToInt32(uid);
            c.Reback_id = null;
            c.Comment_time = DateTime.Now;
            c.Comment_intro = Comment_con;
            c.Comic_id = Convert.ToInt32(cid);
            db.Comment.Add(c);
            db.SaveChanges();
            var a = Convert.ToInt32(coid);
            return RedirectToAction("Detail", new { cid = c.Comic_id, coid = a });
        }
        public ActionResult ALl_More()
        {
            var da = db.Comic;
            return View(da);
        }
    }
}