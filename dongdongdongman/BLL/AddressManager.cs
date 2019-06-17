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
    public class AddressManager 
    {
        IAddress ia = DataAccess.CreateAddress();
        public void Add_Address(string name, string tele, string city, string pro, string quyu, string detail,int udid)
        {
            ia.Add_Address( name,tele,  city,  pro,  quyu,  detail,udid);
        }

        public void Del_Address(int aid)
        {
            ia.Del_Address(aid);
        }

        public void Xiugai_Address(string name, string tele, string city, string pro, string quyu, string detail, int aid)
        {
            ia.Xiugai_Address(name, tele, city, pro, quyu, detail, aid);
        }

    }
}
