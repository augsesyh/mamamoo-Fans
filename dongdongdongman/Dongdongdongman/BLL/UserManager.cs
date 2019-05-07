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
    }
}
