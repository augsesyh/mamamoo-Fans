using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using IDAL;
using Models;
using DALFactory;
namespace BLL
{
    public class FollowManager
    {
        IFollow ifo = DataAccess.CreateFollow();
        public void Add_Follow(int Comic_id,int User_id)
        {
            ifo.Add_Follow(Comic_id, User_id);
        }
        public void Del_Follow(int Comic_id,int User_id)
        {
            ifo.Del_Follow(Comic_id, User_id);
        }

        public IQueryable<Follow> FindByuid(int uid)
        {
            return ifo.FindByuid(uid);
        }
    }
}
