using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DAL;
using DALFactory;
using IDAL;
using Models;
namespace BLL
{
    public class SubscribeManager
    {
        ISubscribe Is = DataAccess.CreateSubscribe();
        public IEnumerable<Subscribe> Findsu(int uid)
        {
            return Is.Findsu(uid);
        }
        public void AddSubscribe(int ccid,int uid )
        {
             Is.AddSubscribe(ccid,uid);
        }
        public void Add_Comic(int coid,int uid)
        {
            Is.Add_Comic(coid, uid);
        }
    }
}