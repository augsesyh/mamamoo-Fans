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
   public class Comic_chapterManager
    {
        IComic_chapter cc = DataAccess.CreateComic_chapter();
        public Comic_chapter FindByid(int ccid)
        {
            return cc.FindByid(ccid);
        }
    }
}
