using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
namespace DAL
{
    class SqlReport:IReport
    {
        dongdongdongEntities db = new dongdongdongEntities();
        public void Add_Report(string leibie, string miaoshu, string jb,int uid,string jb1)
        {
            Report rp = new Report();
            if (jb1 == null || jb1 == "")
            {
                rp.Comment_id = Convert.ToInt32(jb);
                rp.Reback_id = null;
            }
            else
            {
                rp.Comment_id = null;
                rp.Reback_id = Convert.ToInt32(jb1);
            }
            rp.Report_category = leibie;
            rp.Report_intro = miaoshu;
            rp.User_id = uid;
            db.Report.Add(rp);
            db.SaveChanges();
        }

        public void Del_Report(int Report_id)
        {
            var da = db.Report.Where(o=>o.Report_id==Report_id).FirstOrDefault();
            db.Report.Remove(da);
            db.SaveChanges();
        }
    }
}
