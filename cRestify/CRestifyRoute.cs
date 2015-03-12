using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace cRestify
{
    public class CRestifyRoute
    {
        public string Method{get;set;}
        public string Path{get;set;}
        public Func<CRestifyRequest, object> Expr { get; set; }

        public override string ToString()
        {
            return Method + ":" + Path;
        }
    }
}
