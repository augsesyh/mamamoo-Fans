﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IDAL
{
   public interface ISubscribe
    {
        IEnumerable<Subscribe> Findsu(int uid);
        void AddSubscribe(int ccid,int uid);
        void Add_Comic(int coid,int uid);
    }
}
