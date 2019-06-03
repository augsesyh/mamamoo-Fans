using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IDAL
{
    public interface IComic_chapter
    {
        Comic_chapter FindByid(int ccid);
    }
}
