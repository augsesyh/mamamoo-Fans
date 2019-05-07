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
    }
}
