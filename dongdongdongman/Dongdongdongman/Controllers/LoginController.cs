using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using Dongdongdongman.Models;
using System.Net.Mail;
using System.Net;
using Dongdongdongman.App_Data;

namespace Dongdongdongman.Controllers
{
    public class LoginController : Controller
    {
        readonly dongdongdongEntities db = new dongdongdongEntities();
        UserManager us = new UserManager();
        User_detailManager ud = new  User_detailManager();

        // GET: Login

        public ActionResult Login()
        {
            if (SqlHelper.GetCookieValue("NameCookie") != "" && SqlHelper.GetCookieValue("PwdCookie") != "")
            {
                //获取Cookie
                string name = SqlHelper.GetCookieValue("NameCookie");
                string pwd = SqlHelper.GetCookieValue("PwdCookie");

                //使用Decode（）解密
                ViewBag.UserName = SqlHelper.Decode(name);
                ViewBag.Pwd = SqlHelper.Decode(pwd);
            }
            return PartialView();
        }
        public ActionResult Index()
        {
            HomeViewModel Home = new HomeViewModel();
            
          
            return View(Home);
        }
       
       [HttpPost]
        [ValidateAntiForgeryToken]
        public int Login(string uname,string upwd)
        {
            var cok = Request.Form["checkname"];
            if (cok != null)
            {
                SqlHelper.SetCookie("NameCookie", SqlHelper.Encode(uname), DateTime.Now.AddDays(7));
                SqlHelper.SetCookie("PwdCookie", SqlHelper.Encode(upwd), DateTime.Now.AddDays(7));
            }
            var da = us.FindUser(uname, upwd);
            if(da!=null)
            { 
                Session["User_name"] = da.User_detail.User_name;
                Session["User_head"] = da.User_detail.User_head;

                return 1;
            }
            else
            { return 0; }
           
        }
        [HttpPost]
        public string Findsame(string name)
        {
            var da = ud.Findsame(name);
            if(da!=null)
            {
                return "false";
            }else
            {
                return "true";
            }
        }
        [HttpPost]
        public string Findaccount(string account)
        {
            var fa = us.Findaccount(account);
            if (fa != null)
            {
                return "false";
            }
            else
            {
                return "true";
            }
        }
        [HttpPost]
        public string FindEmail(string Email)
        {
            var fa = us.Findaccount(Email);
            if (fa != null)
            {
                return "false";
            }
            else
            {
                return "true";
            }
        }
        [HttpGet]
        public ActionResult AddUser()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(string name,string account,string Email,string upwd,string realname)
        {
           int i =  ud.Add_detail(name, realname, Email);
            us.Add_User(account, upwd, i);
            Session["User_name"] = name;
            return RedirectToAction("Index");
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public string SendValicode(string inputEmail)
        {   
            Session["User_account"] = us.FindUser(inputEmail).User_account;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("2786250969@qq.com");
            //收件人邮箱地址。
            mailMessage.To.Add(new MailAddress(inputEmail));
            //邮件标题。
            mailMessage.Subject = "这是你的验证码";
            string verificationcode = Createrandom(6);
            //邮件内容。
            Session["valicode"] = verificationcode;
            mailMessage.Body = "你的验证码是" + verificationcode;
            //实例化一个SmtpClient类。
            SmtpClient client = new SmtpClient();
            //在这里我使用的是qq邮箱，所以是smtp.qq.com，如果你使用的是126邮箱，那么就是smtp.126.com。
            client.Host = "smtp.qq.com";
            //使用安全加密连接。
            client.EnableSsl = true;
            //不和请求一块发送。
            client.UseDefaultCredentials = false;
            //验证发件人身份(发件人的邮箱，邮箱里的生成授权码);
            client.Credentials = new NetworkCredential("2786250969@qq.com","tdvhtetdyalqdgic");
            //发送
            client.Send(mailMessage);
            return "发送成功";
           
        }

        private string Createrandom(int codelengh)
        {
            int rep = 0;
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < codelengh; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }
        [HttpPost]
        public string Testvalicode(string valicode)
        {
            if(valicode==Session["valicode"].ToString())
            {

                return "验证成功";
            }
            else
            {
                return "验证失败";
            }
        }
        public ActionResult LoginOut()
        {
            Session["User_name"] = null;
            Session["User_account"] = null;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public string Findpassword(string newpw)
        {
            string ac = Session["User_account"].ToString();
            string pw=us.Findpassword(ac).User_password.Trim();
            if(pw==newpw)
            {
                return "false";
            }else
            {
                return "true";
            }
        }
        [HttpPost]
        public ActionResult Changepwd(string newpw)
        {
            string dad = Session["User_account"].ToString();
            us.Changepwd(newpw, dad);
            return RedirectToAction("Index");
        }
    }
}