using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using IDAL;
using Models;

namespace BLL
{
    public class UPManager
    {
        IUP iup = DataAccess.CreateUP();
        public UP FindAllUP(string account, string password)
        {
            return iup.FindAllUP(account,password);
        }
        public UP Findaccount(string account)
        {
            return iup.Findaccount(account);
        }
        public  int Add_User(string account,string upwd,int a)
        {
            return  iup.Add_User(account,upwd,a);
        }
        public UP FindUP(string email)
        {
            return iup.FindUP(email);
        }

    }
}
