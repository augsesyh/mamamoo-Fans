using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IDAL
{
   public interface IComic
    {
        IQueryable<Comic> NewComics();
        IQueryable<Comic> TopEight();
        IQueryable<Comic_chapter> Up_new();
        Comic FindComic(int id);
        IQueryable<Comic> FindTop(int nums);
    }
}
