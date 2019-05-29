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
        public IQueryable<Comic> cm;
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
        public Comic_Fenlei(string[] List)
        {
           
            IQueryable<Comic> te=db.Comic;
            var i = te.Count();
            if (List[0] != "全部")
            {
                var t = List[0];
                te = te.Where(o => o.Colors == t);
                i = te.Count();
            }
            if (List[1] != "全部")
            {
                var t = List[1];
                te = te.Where(o => o.Audiences == t);
                i = te.Count();
            }
            if (List[2] != "全部")
            {
                var t = List[2];
                te = te.Where(o => o.Contents == t);
                i = te.Count();
            }
            if (List[3] != "全部")
            {
                var t = List[3];
                te = te.Where(o => o.Territory == t);
                i = te.Count();
            }
            if (List[4] != "全部")
            {
                var t = List[4];
                te = te.Where(o => o.Forms ==t);
                i = te.Count();
            }
            cm = te;
    }
    }
}