using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHapi {

  public class JsonNetSerializer : IJsonSerializer {
    public string Serialize(object obj) {
      return JsonConvert.SerializeObject(obj);
    }
  }
}
