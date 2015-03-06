using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cRestify {

  public class Response {

    private readonly IOwinResponse response;


    public Response(IOwinResponse response) {
      this.response = response;
    }

    public IHeaderDictionary cache(string[] options) {
      /* if (typeof(type) !== 'string') {
         options = type;
         type = 'public';
       }

       if (options && options.maxAge !== undefined) {
         assert.number(options.maxAge, 'options.maxAge');
         type += ', max-age=' + options.maxAge;
       }
       return (this.header('Cache-Control', type));*/
      response.Headers.Add("Cache-Control", options);
      return response.Headers;

    }
    public string CharSet { get; set; }

    public IOwinResponse format(IOwinResponse response) { throw new NotImplementedException(); }
    public IOwinResponse get(IOwinResponse response) { throw new NotImplementedException(); }
    public IOwinResponse getHeaders(IOwinResponse response) { throw new NotImplementedException(); }
    public IOwinResponse headers(IOwinResponse response) { throw new NotImplementedException(); }
    public IOwinResponse header(IOwinResponse response) { throw new NotImplementedException(); }
    public IOwinResponse json(IOwinResponse response) { throw new NotImplementedException(); }
    public IOwinResponse link(IOwinResponse response) { throw new NotImplementedException(); }
    public IOwinResponse send(IOwinResponse response) { throw new NotImplementedException(); }
    public IOwinResponse set(IOwinResponse response) { throw new NotImplementedException(); }
    public IOwinResponse status(IOwinResponse response) { throw new NotImplementedException(); }
    public IOwinResponse writeHead(IOwinResponse response) { throw new NotImplementedException(); }

  }
}
