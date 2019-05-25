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

    }
}