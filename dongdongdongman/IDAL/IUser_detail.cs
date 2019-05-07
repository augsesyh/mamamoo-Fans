using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IDAL
{
    public interface IUser_detail
    {
        User_detail Findsame(string name);
        int Add_detail(string name, string realname, string Email);
    }
}
