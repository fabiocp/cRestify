using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cRestify {

  public class Server {

    private readonly IAppBuilder app;

    public Server(IAppBuilder app) {
      this.app = app;
    }

    public void Post(string path, Func<IOwinRequest, IOwinResponse, Task> handler) {
      app.Run(context => {
        if (context.Request.Path.Value == path) {
          context.Request.ContentType = "text/plain";
          return handler.Invoke(context.Request, context.Response);
        }
        context.Response.StatusCode = 404;
        return Task.Delay(0);
      });
    }

    public void Put(string path, Func<IOwinRequest, IOwinResponse, Task> handler) {
      app.Run(context => {
        if (context.Request.Path.Value == path) {
          context.Request.ContentType = "text/plain";
          return handler.Invoke(context.Request, context.Response);
        }
        context.Response.StatusCode = 404;
        return Task.Delay(0);
      });
    }

    public void Del(string path, Func<IOwinRequest, IOwinResponse, Task> handler) {
      app.Run(context => {
        if (context.Request.Path.Value == path) {
          context.Request.ContentType = "text/plain";
          return handler.Invoke(context.Request, context.Response);
        }
        context.Response.StatusCode = 404;
        return Task.Delay(0);
      });
    }

    public void Get(string path, Func<IOwinRequest, IOwinResponse, Task> handler) {
      app.Run(context => {
        if (context.Request.Path.Value == path) {
          context.Request.ContentType = "text/plain";
          return handler.Invoke(context.Request, context.Response);
        }
        context.Response.StatusCode = 404;
        return Task.Delay(0);
      });
    }

    public void Resource(Object Todo) {
      throw new NotImplementedException();
    }
  }
}
