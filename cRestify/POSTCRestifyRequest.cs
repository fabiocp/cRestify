using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cRestify
{
    public class POSTCRestifyRequest : CRestifyRequest
    {
        public POSTCRestifyRequest(IOwinRequest owinRequest) : base(owinRequest) { 
        
        }
        public override IDictionary<string, object> GetParams()
        {
            throw new NotImplementedException();
        }
    }
}
