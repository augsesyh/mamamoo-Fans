using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using DALFactory;
using Models;
namespace BLL
{
    public class ReportManager
    {
        IReport ar = DataAccess.CreateReport(); 
        public void Add_Report(string leibie, string miaoshu, string jb, int uid)
        {
            ar.Add_Report(leibie, miaoshu, jb, uid);
        }

    }
}
