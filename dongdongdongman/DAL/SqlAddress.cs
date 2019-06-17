using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;
namespace DAL
{
    class SqlAddress : IAddress
    {
        dongdongdongEntities db = new dongdongdongEntities();
        public void Add_Address(string name, string tele, string city, string pro, string quyu, string detail,int uid)
        {
            Address ad = new Address() ;
            ad.Address_city = city;
            ad.Address_detail = detail;
            ad.Address_name = name;
            ad.Address_phone = tele;
            ad.Address_province = pro;
            ad.Address_quyu = quyu;
            ad.User_id = uid;
            db.Address.Add(ad);
            db.SaveChanges();
        }

        public void Del_Address(int aid)
        {
            var da = db.Address.Where(o=>o.Address_id==aid).FirstOrDefault();
            db.Address.Remove(da);
            db.SaveChanges();
        }

        public void Xiugai_Address(string name, string tele, string city, string pro, string quyu, string detail, int aid)
        {
            var da = db.Address.Where(o=>o.Address_id==aid).FirstOrDefault();
            da.Address_name = name;
            da.Address_city = city;
            da.Address_detail = detail;
            da.Address_phone = tele;
            da.Address_province = pro;
            da.Address_quyu = quyu;
            db.SaveChanges();
        }
    }
}
