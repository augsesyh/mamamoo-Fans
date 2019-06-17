using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IDAL
{
   public interface IFollow
    {
        void Add_Follow(int Comic_id,int User_id);
        void Del_Follow(int Comic_id, int User_id);
        IQueryable<Follow> FindByuid(int uid);
    }
}
