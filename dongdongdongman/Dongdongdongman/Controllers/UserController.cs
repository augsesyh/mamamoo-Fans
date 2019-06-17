using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDAL;
using DAL;
using BLL;
using Models;
using System.IO;

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
        public string Save_img(HttpPostedFileBase file, string Save)
        {
            //得到的名字是文件在本地机器的绝对路径
            var strLocalFullPathName = file.FileName;
            //提取出单独的文件名，不需要路径
            var strFileName = Path.GetFileName(strLocalFullPathName);
            //定义服务器的文件夹，用来保存文件
            var strServerFilePath = Server.MapPath(Save);
            //将接收到文件保存在服务器指定上当
            file.SaveAs(Path.Combine(strServerFilePath, strFileName));
            return Save + "/" + strFileName;
        }
        public ActionResult Xiugai_img(HttpPostedFileBase file)
        {
            
            string file2 = Save_img(file, "/Img/User_head");
            string i = Session["User_name"].ToString();
            var da = db.User_detail.Where(o => o.User_name == i).FirstOrDefault();
            da.User_head = file2;
            db.SaveChanges();
            return RedirectToAction("Detail");
        }
        public ActionResult Address()
        {
            int uid = Convert.ToInt32(Session["User_id"].ToString());
            var da = db.Address.Where(o => o.User_id == uid);
            return View(da);
            
        }
        [HttpPost]
        public ActionResult Add_Address(string name,string detail,string quyu,string pro,string tele,string city)
        {
            int uid = Convert.ToInt32(Session["User_id"].ToString());
            if (!detail.Contains(quyu))
            {
                detail = quyu+detail;
            }
            if (!detail.Contains(city))
            {
                detail = city + detail;
            }
            if (!detail.Contains(pro))
            {
                detail = pro + detail;
            }
            AddressManager am = new AddressManager();
            am.Add_Address(name, tele, city, pro, quyu, detail, uid);
            return RedirectToAction("Address_List");
        }
        public ActionResult Address_List()
        {
            int uid = Convert.ToInt32(Session["User_id"].ToString());
            var da = db.Address.Where(o => o.User_id == uid);
            return PartialView(da);
        }
        [HttpPost]
        public ActionResult Xiugai_Address(string name, string detail, string quyu, string pro, string tele, string city,int aid)
        {
            if (!detail.Contains(quyu))
            {
                detail = quyu + detail;
            }
            if (!detail.Contains(city))
            {
                detail = city + detail;
            }
            if (!detail.Contains(pro))
            {
                detail = pro + detail;
            }
            AddressManager am = new AddressManager();
            am.Xiugai_Address(name, tele, city, pro, quyu, detail, aid);
            return RedirectToAction("Address");
        }
        [HttpPost]
        public ActionResult Del_Address(int aid)
        {
            AddressManager am = new AddressManager();
            am.Del_Address(aid);
            return RedirectToAction("Address_List");
        }
        public ActionResult Orders()
        {
            return View();
        }
        public ActionResult Shoppingcart()
        {
            int uid = Convert.ToInt32(Session["User_id"].ToString());
            ShoppingCartManager scm = new ShoppingCartManager();
           var da = scm.FindshoppingCarts(uid);
            return View(da);
        }
        public ActionResult ShoppingCart_List()
        {
            int uid = Convert.ToInt32(Session["User_id"].ToString());
            ShoppingCartManager scm = new ShoppingCartManager();
           var dt= scm.FindshoppingCarts(uid);
            return PartialView(dt);
        }
        [HttpPost]
        public ActionResult Low_ShoppingCart(int sid)
        {
            ShoppingCartManager scm = new ShoppingCartManager();
            scm.low_ShoppingCart(sid);
            return RedirectToAction("ShoppingCart_List");
        }
        [HttpPost]
        public ActionResult Add_ShoppingCart(int sid)
        {
            ShoppingCartManager scm = new ShoppingCartManager();
            scm.Add_ShoppingCart(sid);
            return RedirectToAction("ShoppingCart_List");
        }
        public ActionResult Follow()
        {
            int uid = Convert.ToInt32(Session["User_id"].ToString());
            FollowManager fm = new FollowManager();
            var da = fm.FindByuid(uid);
            return View(da);
        }
        public ActionResult Follow_List()
        {
            int uid = Convert.ToInt32(Session["User_id"].ToString());
            FollowManager fm = new FollowManager();
            var da = fm.FindByuid(uid);
            return  PartialView(da);
        }
        [HttpPost]
        public ActionResult Del_Follow(int cid)
        {
            int uid = Convert.ToInt32(Session["User_id"].ToString());
            FollowManager fm = new FollowManager();
            fm.Del_Follow(cid, uid);
            return RedirectToAction("Follow_List");
        }
        public ActionResult Collection()
        {
            int uid = Convert.ToInt32(Session["User_id"].ToString());
            CollectionManager cm = new CollectionManager();
            var da = cm.FindByuid(uid);
            return View(da);
        }
        
        public ActionResult Del_Collection(int cid)
        {
            CollectionManager cm = new CollectionManager();
            cm.Del_Collection(cid);
            return RedirectToAction("Collection");
        }
    }
}