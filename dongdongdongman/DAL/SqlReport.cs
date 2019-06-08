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
        public void Add_Report(string leibie, string miaoshu, string jb,int uid)
        {
            Report rp = new Report();
            rp.Comment_id=Convert.ToInt32(jb);
            rp.Report_category = leibie;
            rp.Report_intro = miaoshu;
            rp.User_id = uid;
            db.Report.Add(rp);
            db.SaveChanges();
        }

       
    }
}
