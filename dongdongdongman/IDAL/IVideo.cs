using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IDAL
{
    public interface IVideo
    {
        IQueryable<Video> GetNew();
        IQueryable<Video> GetByStr(string str);
        void Del_Video(int vid);
    }
}
