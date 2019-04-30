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
        User_detailManager ud = new  User_detailManager();
    
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
       
       [HttpPost]
        [ValidateAntiForgeryToken]
        public int Login(string uname,string upwd)
        {
            var da = us.FindUser(uname, upwd);
            if(da!=null)
            { 
                Session["User_name"] = da.User_detail.User_name;
                return 1;
            }
            else
            { return 0; }
           
        }
        [HttpPost]
        public Boolean Findsame(string name)
        {
            var da = ud.Findsame(name);
            if(da!=null)
            {
                return true;
            }else
            {
                return false;
            }
        }
        [HttpPost]
        public Boolean Findaccount(string account)
        {
            var fa = us.Findaccount(account);
            if (fa != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ActionResult AddUser()
        {

            return View();
        }
      
       
    }
}