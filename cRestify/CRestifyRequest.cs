using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cRestify
{
    public abstract class CRestifyRequest
    {
        protected IOwinRequest owinRequest;
        public CRestifyRequest(IOwinRequest owinRequest) {
            this.owinRequest = owinRequest;
        }

        public abstract IDictionary<string, object> GetParams();

        public static CRestifyRequest Factory(IOwinRequest owinRequest)
        {
            if (owinRequest.Method == "GET")
            {
                return new POSTCRestifyRequest(owinRequest);
            }
            return new GETCRestifyRequest(owinRequest);
        }
    }
}
