using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using DALFactory;

namespace BLL
{
    public class UP_detailManager
    {
        IUP_detail iupd = DataAccess.CreateUP_detail();
        public User_detail Findsame(string name)
        {
            return iupd.Findsame(name);
        }
        public int Add_Detail(string name,string realname,string email)
        {
            return iupd.Add_detail(name,realname,email);
        }
    }
}
