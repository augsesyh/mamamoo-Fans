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
    public class User_detailManager
    {
        IUser_detail iud = DataAccess.CreateUser_detail();
       public User_detail Findsame(string name)
        {
            return iud.Findsame(name);
        }
        public int Add_detail(string name, string realname, string Email)
        {
            return iud.Add_detail(name, realname, Email);
        }
    }
}
