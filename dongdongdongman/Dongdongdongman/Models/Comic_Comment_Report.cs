using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using Models;
using BLL;
namespace Dongdongdongman.Models
{
    public class Comic_Comment_Report
    {
        dongdongdongEntities db = new dongdongdongEntities();
        public IEnumerable<Report> Re;
        public IEnumerable<Report> Regg;
        public IEnumerable<Report> Reyh;
        public IEnumerable<Report> Remr;
        public IEnumerable<Report> Rexl;
        public IEnumerable<Comment> co;
        public IEnumerable<ReBack> Reb;
        public IEnumerable<Comment> co1;
        public IEnumerable<ReBack> Reb1;
        public IEnumerable<Comment> co2;
        public IEnumerable<ReBack> Reb2;
        public IEnumerable<Comment> co3;
        public IEnumerable<ReBack> Reb3;
        public IEnumerable<Comment> co4;
        public IEnumerable<ReBack> Reb4;
        public Comic_Comment_Report()
        {
            Re = db.Report;
            Regg = Re.Where(o => o.Report_category.Trim() == "广告，发布谣言");
            Reyh = Re.Where(o => o.Report_category.Trim() == "淫秽，色情");
            Remr = Re.Where(o => o.Report_category.Trim() == "出口成脏");
            Rexl = Re.Where(o => o.Report_category.Trim() == "泄露国家机密");
            
            List<Report> a= Re.ToList<Report>();
            List<Report> gg = new List<Report>();
            gg.AddRange(a.Where(o => o.Report_category == "广告，发布谣言").ToList<Report>());
            List<Report> yh = new List<Report>();
            yh.AddRange(a.Where(o => o.Report_category == "淫秽，色情").ToList<Report>());
            List<Report> mr = new List<Report>();
            mr.AddRange(a.Where(o => o.Report_category == "出口成脏").ToList<Report>());
            List<Report> xlmm = new List<Report>();
            xlmm.AddRange(a.Where(o => o.Report_category == "泄露国家机密").ToList<Report>());
            List<Comment> b=new List<Comment>();
            List<ReBack> c=new List<ReBack>();
            foreach(var it in Re)
            {
                if (it.Comment_id != null)
                {
                    b.Add(it.Comment);

                }
                else
                {
                    c.Add(it.ReBack);
                }
            }
            co = b.ToArray();
            Reb = c.ToArray();
            b.Clear();
            c.Clear();
            foreach(var it in gg)
            {
                if (it.Comment_id != null)
                {
                    b.Add(it.Comment);

                }
                else
                {
                    c.Add(it.ReBack);
                }
            }
            co1 = b;
            Reb1 = c;
            b.Clear();
            c.Clear();
            foreach (var it in yh)
            {
                if (it.Comment_id != null)
                {
                    b.Add(it.Comment);

                }
                else
                {
                    c.Add(it.ReBack);
                }
            }
            co2 = b;
            Reb2 = c;
            b.Clear();
            c.Clear();
            foreach (var it in mr)
            {
                if (it.Comment_id != null)
                {
                    b.Add(it.Comment);

                }
                else
                {
                    c.Add(it.ReBack);
                }
            }
            co3 = b;
            Reb3 = c;
            b.Clear();
            c.Clear();
            foreach (var it in xlmm)
            {
                if (it.Comment_id != null)
                {
                    b.Add(it.Comment);

                }
                else
                {
                    c.Add(it.ReBack);
                }
            }
            co4 = b;
            Reb4 = c;
            b.Clear();
            c.Clear();
        }
        
    }

}