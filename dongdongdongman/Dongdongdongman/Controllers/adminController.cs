using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
namespace Dongdongdongman.Controllers
{
    public class adminController : Controller
    {
        AdminManager am = new AdminManager();
        // GET: admin
        public ActionResult Index()
        {
            var na = Session["admin_name"].ToString();
            var ad = am.Findbynameal(na);
            return View(ad);
        }
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(string name,string pwd)
        {
            
            var da = am.FindByname(name, pwd);
            if(da==null)
            {
                return Content("<script>alerrt('输入密码错误');window.location.href = window.location.href;</script>");
            }else
            {
                Session["admin_name"] = da.admin_access;
                return RedirectToAction("Index","admin");
            }
        }
    }
}