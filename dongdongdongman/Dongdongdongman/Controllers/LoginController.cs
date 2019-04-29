using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace Dongdongdongman.Controllers
{
    public class LoginController : Controller
    {
        dongdongdongEntities db = new dongdongdongEntities();
        UserManager us = new UserManager();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string uname,string upwd)
        {
            var da = us.FindUser(uname, upwd);
            if(da==null)
            {
                return Content("<script>alert('登录失败，账号密码错误');window.location.reload();</script>");
            }
            else
            {
                Session["User"] = da;
                return Content("<script>alert('登录成功');window.location.reload();</script>");
            }
           
        }
        
        public ActionResult AddUser()
        {

            return View();
        }
    }
}