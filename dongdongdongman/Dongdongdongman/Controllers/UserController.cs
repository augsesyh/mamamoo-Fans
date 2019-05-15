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
    }
}