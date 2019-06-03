using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IDAL
{
   public interface IComic_pager
    {
        Comic_pager FindBynums(int nums,int ccid); 
    }
}
