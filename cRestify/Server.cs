using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace cRestify {

  public static class It {
    
    public static TValue IsAny<TValue>() {
      return default(TValue);
    }
  }

  public interface ISetupSetter<TMock> where TMock : class {
  }

  public class SetterMethodCall<TMock> : ISetupSetter<TMock>
    where TMock : class {
  }
  internal static class PexProtector {
    public static void Invoke( Action action ) {
      action();
    }

    public static T Invoke<T>( Func<T> function ) {
      return function();
    }
  }

  public class Server {

    private readonly IAppBuilder app;

    public Server( IAppBuilder app ) {
      this.app = app;
    }

    public void Post( string path, Func<IOwinRequest, IOwinResponse, Task> handler ) {
      app.Run(context => {
        if (context.Request.Path.Value == path) {
          context.Request.ContentType = "text/plain";
          return handler.Invoke(context.Request, context.Response);
        }
        context.Response.StatusCode = 404;
        return Task.Delay(0);
      });
    }

    public void Put( string path, Func<IOwinRequest, IOwinResponse, Task> handler ) {
      app.Run(context => {
        if (context.Request.Path.Value == path) {
          context.Request.ContentType = "text/plain";
          return handler.Invoke(context.Request, context.Response);
        }
        context.Response.StatusCode = 404;
        return Task.Delay(0);
      });
    }

    public void Del( string path, Func<IOwinRequest, IOwinResponse, Task> handler ) {
      app.Run(context => {
        if (context.Request.Path.Value == path) {
          context.Request.ContentType = "text/plain";
          return handler.Invoke(context.Request, context.Response);
        }
        context.Response.StatusCode = 404;
        return Task.Delay(0);
      });
    }

    /* public void Get(string path, Func<IOwinRequest, IOwinResponse, Task> handler) {
       app.Run(context => {
         if (context.Request.Path.Value == path) {
           context.Request.ContentType = "text/plain";
           return handler.Invoke(context.Request, context.Response);
         }
         context.Response.StatusCode = 404;
         return Task.Delay(0);
       });
     }*/


    public void Get<T>( string path, Action<T> handler ) where T : class {
      app.Run(context => {
        if (context.Request.Path.Value == path) {
          context.Request.ContentType = "text/plain";
          handler.ToString();
          return context.Response.WriteAsync("Hello World");
        }
        //context.Response.StatusCode = 404;
        return Task.Delay(0);
      });


    /*  return PexProtector.Invoke(() => {
                return SetupSetImpl<T, SetterMethodCall<T, TProperty>>(mock, setterExpression, ( m, expr, method, value ) => {
                  var call = new SetterMethodCall<T, TProperty>(m, condition, expr, method, value[0]);
                  m.Interceptor.AddCall(call, SetupKind.PropertySet);
                  return call;
                });
              });*/
    }


  }
}
