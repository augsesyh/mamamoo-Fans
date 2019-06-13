using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDAL;
using DAL;
using BLL;
using Models;

namespace Dongdongdongman.Controllers
{
    public class UserController : Controller
    {
        User_detailManager ud = new User_detailManager();
        dongdongdongEntities db = new dongdongdongEntities();
        // GET: User
        public ActionResult Index()
        {
            string i = Session["User_name"].ToString();
            var da = ud.Findsame(i);
            return PartialView(da);
        }
        public ActionResult Detail()
        {
            string j = Session["User_name"].ToString();
            var da = ud.Findsame(j);
            return View(da);
        }
        public ActionResult Detail_user()
        {
            string j = Session["User_name"].ToString();
            var da = ud.Findsame(j);
            return PartialView(da);
        }
        [HttpPost]
        public ActionResult Xiugai_de(string real_name,string Email,string intro)
        {
            string i = Session["User_name"].ToString();
            var da = db.User_detail.Where(o=>o.User_name==i).FirstOrDefault();
            da.User_realname = real_name;
            da.User_intro = intro;
            da.User_email = Email;
            db.SaveChanges();
            return PartialView("Detail_user", da);
        }
        public ActionResult Xiugai_img(HttpPostedFileBase file)
        {
            adminController ac = new adminController();
            string file2 = ac.Save_img(file, "/Img/User_head");
            string i = Session["User_name"].ToString();
            var da = db.User_detail.Where(o => o.User_name == i).FirstOrDefault();
            da.User_head = file2;
            return RedirectToAction("Detail");
        }
    }
}