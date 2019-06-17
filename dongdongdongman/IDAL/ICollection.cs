using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IDAL
{
    public interface ICollection
    {
        IQueryable<Collection> FindByuid(int uid);
        void Del_Collection(int cid);
    }
}
