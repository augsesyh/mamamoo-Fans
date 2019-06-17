using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IReport
    {
        void Add_Report(string leibie,string miaoshu,string jb,int uid,string jb1);
        void Del_Report(int Report_id);
    }
}
