using DALFactory;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace BLL
{
    public class UserManager
    {
        IUser iuser = DataAccess.CreateUser();
        public User FindUser(string name,string password)
        {
            return iuser.FindUser(name, password);
        }
        public User Findaccount(string account)
        {
            return iuser.Findaccount(account);
        }
        public void Add_User(string account, string upwd, int a)
        {
            iuser.Add_User(account, upwd, a);
        }
    }
}
