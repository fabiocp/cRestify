using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cRestify {

  public static class It {

    public static TValue IsAny<TValue>() {
      return default(TValue);
    }
  }
}
