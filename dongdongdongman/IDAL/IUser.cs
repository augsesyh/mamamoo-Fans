using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IUser
    {
        User FindUser(string name, string password);
        User Findaccount(string account);
        void Add_User(string account, string upwd,int a);
        User FindUser(string Email);
        User Findpassword(string account);
        void Changepwd(string pwd, string account);
        User Findname(string name);
        }
}
