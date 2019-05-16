using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using IDAL;
using DALFactory;
namespace BLL
{
   public class VideoManager
    {
        IVideo d = DataAccess.CreateVideo();
        public IQueryable<Video> GetNew()
        {
            return d.GetNew();
        }
    }
}
