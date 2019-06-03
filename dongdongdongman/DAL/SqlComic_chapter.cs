using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    public class SqlComic_chapter : IComic_chapter
    {
        dongdongdongEntities db = new dongdongdongEntities();
       Comic_chapter IComic_chapter.FindByid(int ccid)
        {
            return db.Comic_chapter.Where(o=>o.Comic_chapter_id==ccid).FirstOrDefault();
        }
    }
}
