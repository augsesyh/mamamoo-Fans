using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using IDAL;
using DALFactory;
using Models;
namespace BLL
{
    public class AdminManager
    {
        IAdmin ia = DataAccess.CreateAdmin();
        public admin FindByname(string name,string pwd)
        {
            return ia.FindByname(name, pwd);
        }
        public admin Findbynameal(string name)
        {
            return ia.FindBynaal(name);
        }
    }
}
