using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using DAL;
using DALFactory;

namespace BLL
{
    public class CollectionManager : ICollection
    {
        ICollection ic = DataAccess.CreateCollection();

        public void Del_Collection(int cid)
        {
            ic.Del_Collection(cid);
        }

        public IQueryable<Collection> FindByuid(int uid)
        {
            return ic.FindByuid(uid);
        }
    }
}
