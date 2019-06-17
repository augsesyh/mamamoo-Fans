using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using Dongdongdongman.Models;
using Webdiyer.WebControls.Mvc;
using System.Data.Entity.Core.Objects;

namespace Dongdongdongman.Controllers
{
    public class adminController : Controller
    {
        dongdongdongEntities db = new dongdongdongEntities();
        Good_CateManager dcm = new Good_CateManager();
        AdminManager am = new AdminManager();
        // GET: admin
        public ActionResult Index()
        {
            //var na = Session["admin_name"].ToString();
            //var ad = am.Findbynameal(na);
            var ad = dcm.FindALLGoodCate();
            return View(ad);
        }
        public ActionResult Index_xiugai(int Good_id, int Gid = 1)
        {
            ViewBag.id = Gid;
            Admin_Index_xiugai adx = new Admin_Index_xiugai(Good_id);
            return View(adx);
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(string name, string pwd)
        {

            var da = am.FindByname(name, pwd);
            if (da == null)
            {
                return Content("<script>alert('输入密码错误');window.location.href = window.location.href;</script>");
            }
            else
            {
                Session["admin_name"] = da.admin_access;
                return RedirectToAction("Index", "admin");
            }
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
        [HttpPost]
        public ActionResult SaveAs(HttpPostedFileBase file, HttpPostedFileBase file1, string Good_name, string Good_price, string Good_Cate, string Good_nums, string Good_text)
        {

            //得到的名字是文件在本地机器的绝对路径
            string file2 = Save_img(file, "/Img/Good_photo");
            string file3 = Save_img(file1, "/Img/Good_intro");

            int price = Convert.ToInt32(Good_price);
            int nums = Convert.ToInt32(Good_nums);
            //下面只是用来显示一些相关字符串做测试用
            int Cate = Convert.ToInt32(Good_Cate);
            GoodsManager gm = new GoodsManager();
            gm.Add_Goods(Good_name, price, nums, file2, file3, Cate, Good_text);
            return RedirectToAction("Good_List");
        }
        public ActionResult Good_List(int Gid = 1)
        {
            Admin_Index ai = new Admin_Index(Gid);
            if (Request.IsAjaxRequest())
                return RedirectToAction("Goodtable", "admin", new { Gid = Gid });
            return View(ai);
        }
        public ActionResult Goodtable(int Gid = 1)
        {
            ViewBag.id = Gid;
            Admin_Index ai = new Admin_Index(Gid);
            return PartialView(ai);
        }
        [HttpPost]
        public ActionResult Delete_Goods(int Good_id)
        {
            GoodsManager gm = new GoodsManager();
            gm.Detele_Goods(Good_id);
            return RedirectToAction("Goodtable");
        }
        [HttpPost]
        public ActionResult Add_Cate(string Good_Ca)
        {
            Good_CateManager gcm = new Good_CateManager();
            gcm.Add_Cate(Good_Ca);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Good_xiugai(string Gid, string id, HttpPostedFileBase file, HttpPostedFileBase file1, string Good_name, string Good_price, string Good_Cate, string Good_nums, string Good_text)
        {
            string file2, file3;
            GoodsManager gm = new GoodsManager();
            int gid = Convert.ToInt32(id);
            var da = db.Goods.Where(o => o.Goods_id == gid).FirstOrDefault();
            if (file != null)
            {
                file2 = Save_img(file, "/Img/Good_photo");
            }
            else
            {
                file2 = da.Goods_photo;
            }
            da.Goods_photo = file2;
            if (file1 != null)
            {
                file3 = Save_img(file1, "/Img/Good_photo");
            }
            else
            {
                file3 = da.Goods_intro;
            }
            da.Goods_intro = file3;
            da.Goods_name = Good_name;
            da.Goods_nums = Convert.ToInt32(Good_nums);
            da.Goods_price = Convert.ToInt32(Good_price);
            da.Good_intro_text = Good_text;
            da.Goods_cate = Convert.ToInt32(Good_Cate);
            db.SaveChanges();
            int Gid1 = Convert.ToInt32(Gid);
            return RedirectToAction("Good_List", new { Gid = Gid1 });
        }
        [HttpPost]
        public ActionResult FindBystr(string shoushuo)
        {
            if (shoushuo == null || shoushuo.Trim() == "")
            {
                Admin_Index ai1 = new Admin_Index(1);
                return PartialView("Goodtable", ai1);
            }
            GoodsManager gm = new GoodsManager();
            var da = gm.FindBystr(shoushuo).OrderByDescending(o => o.Goods_id).ToPagedList(1, 10);
            Admin_Index ai = new Admin_Index(1);
            ai.g = da;
            return PartialView("Goodtable", ai);
        }
        public ActionResult Comment_Goods_Dele()
        {
            Goods_AssessManager gam = new Goods_AssessManager();
            var da = gam.GetALLAssess();
            return View(da);
        }
        public ActionResult Goods_Assess_table()
        {
            Goods_AssessManager game = new Goods_AssessManager();
            var da = game.GetALLAssess();
            return PartialView(da);
        }
        [HttpPost]
        public ActionResult Del_Assess(int gaid)
        {
            Goods_AssessManager gam = new Goods_AssessManager();
            gam.Del_Assess(gaid);
            return RedirectToAction("Goods_Assess_table");
        }
        public ActionResult Shoushuo_Assess(string user_name, string Good_name, string Assess_intro)
        {
            Goods_AssessManager game = new Goods_AssessManager();
            var da = game.GetALLAssess();

            if (user_name.Trim() != "")
            {
                da = da.Where(o => o.User.User_detail.User_name.IndexOf(user_name) >= 0);
            }
            if (Good_name.Trim() != "")
            {
                da = da.Where(o => o.Goods.Goods_name.IndexOf(Good_name) >= 0);
            }
            if (Assess_intro.Trim() != "")
            {
                da = da.Where(o => o.Assess_intro.IndexOf(Assess_intro) >= 0);
            }
            return PartialView("Goods_Assess_table", da);
        }
        [HttpPost]
        public ActionResult Del_More(string[] Asid)
        {
            foreach(var i in Asid)
            {
                int d = Convert.ToInt32(i);
                var da = db.Goods_Assess.Where(o => o.Assess_id == d).FirstOrDefault();
                db.Goods_Assess.Remove(da);
            }
            db.SaveChanges();
            Goods_AssessManager game = new Goods_AssessManager();
            var da1 = game.GetALLAssess();
            return PartialView("Goods_Assess_table",da1);
        }
        public ActionResult Comics_Index()
        {
            return View(db.Comic);
        }
        public ActionResult Comic_List()
        {
            return PartialView(db.Comic);
        }
        public ActionResult Del_Comic(int cid)
        {
            ComicManager cm = new ComicManager();
            cm.Del_Comic(cid);
            return RedirectToAction("Comic_List");
        }
      
        public ActionResult FindBystr_Comic(string shoushuo)
        {
            if(shoushuo.Trim() == "")
            {
                return PartialView("Comic_List", db.Comic);
            }
            ComicManager cm = new ComicManager();
            var da = cm.FindByName(shoushuo);
            return PartialView("Comic_List",da);
        } 
        public ActionResult Reposort_List()
        {
            Comic_Comment_Report ccr = new Comic_Comment_Report();
            return View(ccr);
        }
        public ActionResult Report_Table()
        {
            Comic_Comment_Report ccr = new Comic_Comment_Report();
            return PartialView(ccr);
        }
        [HttpPost]
        public ActionResult Del_Comment(int Comment_id)
        {
            CommentManager cm = new CommentManager();
            cm.Del_CommentByid(Comment_id);
            return RedirectToAction("Report_Table");
        }
        [HttpPost]
        public ActionResult Del_Report(int Report_id)
        {
            ReportManager rm = new ReportManager();
            rm.Del_Report(Report_id);
            return RedirectToAction("Report_Table");
        }
        public ActionResult UpVideo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpVideo(HttpPostedFileBase file)
        {
            dongdongdongEntities db = new dongdongdongEntities();
            if (file != null && file.ContentLength > 0)
            {
                string folderpath = "/Video/";//上传图片的文件夹
                if (!Directory.Exists(folderpath))
                {
                    Directory.CreateDirectory(Server.MapPath(folderpath));
                }
                string ext1 = Path.GetExtension(file.FileName);
                if (ext1 != ".mp4" && ext1 != ".rmvb" && ext1 != ".avi" && ext1 != ".flv")//笔者这儿修改了后缀的判断
                {
                    return Json(new { statu = 201, msg = "文件格式不正确！" });
                }
                else
                {
                    string folder = Server.MapPath(folderpath);
                    string name = DateTime.Now.ToString("yyyyMMddHHmmssff");
                    string ext = Path.GetExtension(file.FileName);
                    string downpath = name + ext;
                    string filepath = Server.MapPath(folderpath) + name + ext;
                    Video_detail vd = new Video_detail();
                    vd.Video_address = folderpath+downpath;
                    vd.Video_detail_name = "惊奇队长";
                    vd.Video_num = 1;
                    vd.Video_id = 17;
                    db.Video_detail.Add(vd);
                    db.SaveChanges();
                    file.SaveAs(Path.Combine(folder,downpath));
                    
                    return Json(new { status = 200, src = downpath, id = name });
                }
            }
            else
            {
                return Json(new { status = 202, msg = "请上传文件！" });
            }

        }
        public ActionResult Video_list()
        {

            return View(db.Video);
        }
        public ActionResult Video_table()
        {
            return PartialView(db.Video);
        }
        public ActionResult FindBystr_video(string shoushuo)
        {
            VideoManager vm = new VideoManager();
            var da = vm.GetByStr(shoushuo);
            return PartialView("Video_table",da);
        }
        [HttpPost]
        public ActionResult Del_Video(int vid)
        {
            var da = db.Video.Where(o => o.Video_id == vid).FirstOrDefault();
            foreach(var it in da.Video_detail)
            {
                Del_File(it.Video_address);
                 
            }
            db.Video.Remove(da);

            db.SaveChanges();
            return RedirectToAction("Video_table");
        }
        public void Del_File(string way)
        {
            
            var strServerFilePath = Server.MapPath(way);
            //将接收到文件保存在服务器指定上当
            System.IO.File.Delete(strServerFilePath);
            
        }
    }
}