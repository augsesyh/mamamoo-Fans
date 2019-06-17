using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IAddress
    {
         void Add_Address(string name,string tele,string city,string pro,string quyu,string detail,int uid);
        void Xiugai_Address(string name, string tele, string city, string pro, string quyu, string detail,int aid);
        void Del_Address(int aid);
    }
}
