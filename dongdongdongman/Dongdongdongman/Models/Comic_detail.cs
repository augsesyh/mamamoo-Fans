using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using BLL;
using DALFactory;
using Webdiyer.WebControls.Mvc;

namespace Dongdongdongman.Models
{
    public class Comic_detail
    {
        private UserManager us = new UserManager();
        private ComicManager cm=new ComicManager();
        public  IEnumerable<Comic_chapter> ca;
       public PagedList<Comment> co;
       public IEnumerable<Comic> ac;
       public Comic a;
        public User ur;
        public Comic_detail(int id,string name,int coid){
            a = cm.FindComic(id);
            ca = a.Comic_chapter;
            co = a.Comment.OrderByDescending(o=>o.Comment_time).ToPagedList(coid,9);
            ac = cm.FindTop(4);
            ur = us.Findname(name);
       }
    }
}