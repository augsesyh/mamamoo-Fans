using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;
namespace DAL
{
    public class SqlSubscribe : ISubscribe
    {
        dongdongdongEntities db = new dongdongdongEntities();
        IEnumerable<Subscribe> ISubscribe.Findsu(int uid)
        {
            var da = db.Subscribe.Where(o=>o.User_id==uid);
            return da;
        }
    }
}
