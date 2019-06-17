using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;
namespace DAL
{
    public class SqlComment : IComment
    {
        dongdongdongEntities db = new dongdongdongEntities();
        public void Del_CommentByid(int Comment_id)
        {
            var da = db.Comment.Where(o=>o.Comment_id==Comment_id).FirstOrDefault();
            db.Comment.Remove(da);
            db.SaveChanges();

        }
    }
}
