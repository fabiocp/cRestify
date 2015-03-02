using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cRestify {

  public class Router {

    private IDictionary<String, IList<String>> routes;

    public Router() {

      this.routes = new Dictionary<String, IList<String>>();
    }

    /*
        function createCachedRoute(o, path, version, route) {
          if (!o.hasOwnProperty(path))
            o[path] = { };

          if (!o[path].hasOwnProperty(version))
            o[path][version] = route;
        }


        function matchURL(re, req) {
          var i = 0;
          var result = re.exec(req.path());
          var params = { };

          if (!result)
            return (false);

          // This means the user original specified a regexp match, not a url
          // string like /:foo/:bar
          if (!re.restifyParams) {
            for (i = 1; i < result.length; i++)
                params[(i - 1)] = result[i];

            return (params);
        }

        // This was a static string, like /foo
        if (re.restifyParams.length === 0)
            return (params);

        // This was the "normal" case, of /foo/:id
        re.restifyParams.forEach(function(p) {
        if (++i < result.length)
                params[p] = decodeURIComponent(result[i]);
    });

        return (params);
    }


    function compileURL(options) {
      if (options.url instanceof RegExp)
            return (options.url);
      assert.string(options.url, 'url');

      var params = [];
      var pattern = '^';
      var re;
      var _url = url.parse(options.url).pathname;
      _url.split('/').forEach(function(frag) {
        if (frag.length <= 0)
          return (false);

        pattern += '\\/+';
        if (frag.charAt(0) === ':') {
          if (options.urlParamPattern) {
            pattern += '(' + options.urlParamPattern + ')';
          } else {
            pattern += '([^/]*)';
          }
                params.push(frag.slice(1));
        } else {
          pattern += frag;
        }

        return (true);
      });

      if (pattern === '^')
        pattern += '\\/';
      pattern += '$';

      re = new RegExp(pattern, options.flags);
      re.restifyParams = params;

      return (re);
    }*/

    public void render() { throw new NotImplementedException(); }
    public void mount() { throw new NotImplementedException(); }
    public void unmount() { throw new NotImplementedException(); }
    public void get() { throw new NotImplementedException(); }
    public void find() { throw new NotImplementedException(); }
    public void toString() { throw new NotImplementedException(); }

  }
}
