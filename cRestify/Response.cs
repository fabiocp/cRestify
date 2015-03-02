using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cRestify {

  public static class Response {

    public static IHeaderDictionary cache(this IOwinResponse response) {
      /* if (typeof(type) !== 'string') {
         options = type;
         type = 'public';
       }

       if (options && options.maxAge !== undefined) {
         assert.number(options.maxAge, 'options.maxAge');
         type += ', max-age=' + options.maxAge;
       }

       return (this.header('Cache-Control', type));*/
      throw new NotImplementedException();
    }
    public static IOwinResponse charSet(this IOwinResponse response) {
      /*
      assert.string(type, 'charset');

      this._charSet = type;

      return (this);*/
      throw new NotImplementedException();
    }
    public static IOwinResponse format(this IOwinResponse response) { throw new NotImplementedException(); }
    public static IOwinResponse get(this IOwinResponse response) { throw new NotImplementedException(); }
    public static IOwinResponse getHeaders(this IOwinResponse response) { throw new NotImplementedException(); }
    public static IOwinResponse headers(this IOwinResponse response) { throw new NotImplementedException(); }
    public static IOwinResponse header(this IOwinResponse response) { throw new NotImplementedException(); }
    public static IOwinResponse json(this IOwinResponse response) { throw new NotImplementedException(); }
    public static IOwinResponse link(this IOwinResponse response) { throw new NotImplementedException(); }
    public static IOwinResponse send(this IOwinResponse response) { throw new NotImplementedException(); }
    public static IOwinResponse set(this IOwinResponse response) { throw new NotImplementedException(); }
    public static IOwinResponse status(this IOwinResponse response) { throw new NotImplementedException(); }
    public static IOwinResponse writeHead(this IOwinResponse response) { throw new NotImplementedException(); }




  }
}
