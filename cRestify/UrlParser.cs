using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cRestify {

  public class UrlParser {

    public string GetResourceName(string Url) {
      return GetStep(Url, 1);
    }

    public string GetMethodName(string Url) {
      return GetStep(Url, 2);
    }

    public IDictionary<string, string> GetParameterValues(string urlValues, string urlRoute) {
      var dic = new Dictionary<string, string>();
      var steps = urlRoute.Split('/');
      var stepsValues = urlValues.Split('/');
      for(var i = 0; i < steps.Length; i++) {
        if(!steps[i].Contains(":"))
          continue;
        var name = steps[i].Replace(":", "");
        dic[name] = stepsValues[i];
      }

      return dic;
    }

    public string GetStep(string url, int index) {
      return url.Split('/').Skip(index).First();
    }

  }
}
