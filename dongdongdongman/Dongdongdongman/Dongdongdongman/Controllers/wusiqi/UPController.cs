using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace Dongdongdongman.Controllers.wusiqi
{
    public class UPController : Controller
    {
        dongdongdongEntities db = new dongdongdongEntities();
        UPManager um = new UPManager();
        UP_detailManager updm = new BLL.UP_detailManager();
        // GET: UP
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        
        public int CheckLogin(string account,string password)
        {
            
            var da = um.FindAllUP(account, password);
            if(da!=null)
            {
                //UP_account=User_email
                Session["UP_account"] = da.UP_account;
                return 1;
            }
            else
            {
                return 0;
            }
        }

        [HttpPost]
        public string Findsame(string name)
        {
            var fa = updm.Findsame(name);
            if(fa==null)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        public string Findaccount(string account)
        {
            var fa = um.Findaccount(account);
            if(fa==null)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        [HttpPost]
        public string FindEmail(string email)
        {
            var fa = um.Findaccount(email);
            if(fa==null)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
        
        //UP主注册
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public int Register(string name,string account,string email,string password,string realname)
        {
            int i = updm.Add_Detail(name, realname, email);
            int a=um.Add_User(account, password, i);
            if(a!=1)
            { return 0; }
            else
            { return 1; }
        }
    }
}