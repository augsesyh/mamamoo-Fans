using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
namespace Dongdongdongman.Models
{
    public class Comic_Fenlei
    {
        dongdongdongEntities db = new dongdongdongEntities();
        public IEnumerable<Comic> cm;
        public IEnumerable<Colors> co;
        public IEnumerable<Audiences> ad;
        public IEnumerable<Contents> ct;
        public IEnumerable<Territory> te;
        public IEnumerable<Forms> fo;
        public Comic_Fenlei()
        {
            cm = db.Comic;
            co = db.Colors;
            ad = db.Audiences;
            ct = db.Contents;
            te = db.Territory;
            fo = db.Forms;
        }

    }
}