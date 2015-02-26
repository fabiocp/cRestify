using Owin;
using cRestify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cRestify {

  public class Restify {

    private IAppBuilder app;

    public Restify(IAppBuilder app) {
      this.app = app;

    }
    public Server CreateServer() {
      return new Server(app);
    }
  }
}
