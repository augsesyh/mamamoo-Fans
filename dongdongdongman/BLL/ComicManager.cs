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
    public class ComicManager
    {
        IComic Ic = DataAccess.CreateComic();
        public IQueryable<Comic> NewComics()
        {
            return Ic.NewComics();
        }
       public IQueryable<Comic> TopEight()
        {
            return Ic.TopEight();
        }
        public IQueryable<Comic_chapter> UP_New()
        {
            return Ic.Up_new();
        }
        public Comic FindComic(int id)
        {
            return Ic.FindComic(id);
        }
        public IQueryable<Comic> FindTop(int nums)
        {
            return Ic.FindTop(nums);
        }
        public void Del_Comic(int Comic_id)
        {
            Ic.Del_Comic(Comic_id);
        }
        public IQueryable<Comic> FindByName(string name)
        {
            return Ic.GetComicByname(name);
        }
    }
}
