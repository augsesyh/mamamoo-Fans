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
    }
}
