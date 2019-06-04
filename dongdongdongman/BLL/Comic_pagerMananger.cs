using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using IDAL;
using DALFactory;
namespace BLL
{
   public class Comic_pagerMananger
    {
        IComic_pager cp = DataAccess.CreateComic_pager();
        public Comic_pager FindBynums(int cci,int num)
        {
            return cp.FindBynums(cci, num);
        }
    }
}
