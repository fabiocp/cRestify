using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cRestify
{
    public class GETCRestifyRequest : CRestifyRequest
    {
        public GETCRestifyRequest(IOwinRequest owinRequest)
            : base(owinRequest)
        { 
        
        }
        public override IDictionary<string, object> GetParams()
        {
            return null;
        }
    }
}
