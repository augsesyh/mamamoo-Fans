using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IUP
    {
        //UP主登录
        UP FindAllUP(string account,string password);
        UP Findaccount(string account);
        int Add_User(string account,string upwd,int a);
        UP FindUP(string email);
    }
}
