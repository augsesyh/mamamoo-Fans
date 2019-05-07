﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using System.Net.Mail;
using System.Net;

namespace Dongdongdongman.Controllers
{
    public class LoginController : Controller
    {
        readonly dongdongdongEntities db = new dongdongdongEntities();
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
            ViewData["User"]=us.FindUser(inputEmail);
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

    }
}