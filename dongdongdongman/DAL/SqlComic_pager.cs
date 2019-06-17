using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;
namespace DAL
{
    class SqlComic_pager : IComic_pager
    {
        dongdongdongEntities db = new dongdongdongEntities();
        Comic_pager IComic_pager.FindBynums(int ccid,int nums)
        {
            return db.Comic_pager.Where(c=>c.Comic_chapter_id==ccid).Where(o=>o.Comic_page_nums==nums).FirstOrDefault();
        }
    }
}
