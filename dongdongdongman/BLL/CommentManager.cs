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
    public class CommentManager
    {
        IComment ic = DataAccess.CreateComment();

        public void Del_CommentByid(int Comment_id)
        {
            
            ic.Del_CommentByid(Comment_id);
        }
    }
}
