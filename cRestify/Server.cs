using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Fasterflect;

namespace cRestify {

  public static class It {

    public static TValue IsAny<TValue>() {
      return default(TValue);
    }
  }

  public interface ISetupSetter<TMock> where TMock : class {
  }
  public interface ISetup<TMock, TResult> where TMock : class {
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
  internal class CallInfo {
    public Expression Object { get; set; }
    public MethodInfo Method { get; set; }
    public IEnumerable<Expression> Arguments { get; set; }
  }


  public class Server {

    private readonly IAppBuilder app;

    private Router route;

    public Server( IAppBuilder app ) {
      this.app = app;
      this.route = new Router();
    }

    private void handle( string path, Func<IOwinRequest, IOwinResponse, Task> handler ) { }
    private void Route( string path, Func<IOwinRequest, IOwinResponse, Task> handler ) { }
    private void run( string path, Func<IOwinRequest, IOwinResponse, Task> handler ) { }
    private void setupRequest( string path, Func<IOwinRequest, IOwinResponse, Task> handler ) { }
    /*
        public void Del(string path, Func<IOwinRequest, IOwinResponse, Task> handler) {
          app.Run(context => {
            if(context.Request.Path.Value == path) {
              context.Request.ContentType = "text/plain";
              return handler.Invoke(context.Request, context.Response);
            }
            context.Response.StatusCode = 404;
            return Task.Delay(0);
          });
        }

        public void Get(string path, Func<IOwinRequest, IOwinResponse, Task> handler) {
          app.Run(context => {
            if(context.Request.Path.Value == path) {
              context.Request.ContentType = "text/plain";
              return handler.Invoke(context.Request, context.Response);
            }
            context.Response.StatusCode = 404;
            return Task.Delay(0);
          });
        }*/


    private static object CreateInstance( Type classType ) {
      var creator = classType.CreateInstance();
      return creator;
    }

    private static Func<object> GetCreator( Type classType ) {
      Expression body;
      const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
      var defaultConstructor = classType.GetConstructor(bindingFlags, null, new Type[0], null);
      if (defaultConstructor != null) {
        body = Expression.New(defaultConstructor);
      } else {
        var getUnitializedObjectMethodInfo = typeof(FormatterServices).GetMethod("GetUninitializedObject", BindingFlags.Public | BindingFlags.Static);
        body = Expression.Call(getUnitializedObjectMethodInfo, Expression.Constant(classType));
      }
      var lambdaExpression = Expression.Lambda<Func<object>>(body);
      return lambdaExpression.Compile();

    }
    /*
        public void Get<T>( string path, Action<T> handler ) where T : class {
          app.Run(context => {
            //     if (context.Request.Path.Value == path) {
            context.Request.ContentType = "text/plain";
            //handler.ToString();
            var obj =  (T)CreateInstance(typeof(T));
            handler(obj);
            var setterExpressionParameters = handler.GetMethodInfo();
            var res = obj.CallMethod("HelloWord");

            // var methodInfo = obj.UnwrapIfWrapped().GetType().Method("Walk", Flags.InstanceAnyVisibility);
            //methodInfo.Call(obj);
            //handler.Invoke(obj);
            /*return PexProtector.Invoke(() => {
              return SetupSetImpl<T, SetterMethodCall<T, TProperty>>(mock, setterExpression, ( m, expr, method, value ) => {
                var call = new SetterMethodCall<T, TProperty>(m, condition, expr, method, value[0]);
                m.Interceptor.AddCall(call, SetupKind.PropertySet);
                return call;
              });
            });*/
    //return context.Response.WriteAsync(res);
    //}
    /* context.Response.StatusCode = 404;
     return Task.Delay(0);
   });
 }
*/

    public void Get<T, TResult>( string path, Expression<Func<T, TResult>> expression ) where T : class {
      app.Run(context => {
        //     if (context.Request.Path.Value == path) {
        context.Request.ContentType = "text/plain";
        //handler.ToString();
        var obj =  (T)CreateInstance(typeof(T));
        //handler(obj);
        // var setterExpressionParameters = handler.GetMethodInfo();
        var res = obj.CallMethod("HelloWord");
        var aaa = expression.Name;
        // var methodInfo = obj.UnwrapIfWrapped().GetType().Method("Walk", Flags.InstanceAnyVisibility);
        //methodInfo.Call(obj);
        //handler.Invoke(obj);
        /*return PexProtector.Invoke(() => {
          return SetupSetImpl<T, SetterMethodCall<T, TProperty>>(mock, setterExpression, ( m, expr, method, value ) => {
            var call = new SetterMethodCall<T, TProperty>(m, condition, expr, method, value[0]);
            m.Interceptor.AddCall(call, SetupKind.PropertySet);
            return call;
          });
        });*/
        //return context.Response.WriteAsync(res);
        //}
        context.Response.StatusCode = 404;
        return Task.Delay(0);
      });
    }


    public void Get<T>( string path, Action<T> handler ) where T : class {
      app.Run(context => {
        //     if (context.Request.Path.Value == path) {
        context.Request.ContentType = "text/plain";
        //handler.ToString();
        var obj =  (T)CreateInstance(typeof(T));
        handler(obj);
        // var setterExpressionParameters = handler.GetMethodInfo();
        // var res = obj.CallMethod("HelloWord");
        //var aaa = expression.Name;
        // var methodInfo = obj.UnwrapIfWrapped().GetType().Method("Walk", Flags.InstanceAnyVisibility);
        //methodInfo.Call(obj);
        //handler.Invoke(obj);
        /*return PexProtector.Invoke(() => {
          return SetupSetImpl<T, SetterMethodCall<T, TProperty>>(mock, setterExpression, ( m, expr, method, value ) => {
            var call = new SetterMethodCall<T, TProperty>(m, condition, expr, method, value[0]);
            m.Interceptor.AddCall(call, SetupKind.PropertySet);
            return call;
          });
        });*/
        //return context.Response.WriteAsync(res);
        //}
        context.Response.StatusCode = 202;
        return Task.Delay(0);
      });
    }


    /*
        public void head(string path, Func<IOwinRequest, IOwinResponse, Task> handler) {
          app.Run(context => {
            if(context.Request.Path.Value == path) {
              context.Request.ContentType = "text/plain";
              return handler.Invoke(context.Request, context.Response);
            }
            context.Response.StatusCode = 404;
            return Task.Delay(0);
          });
        }

        public void opts(string path, Func<IOwinRequest, IOwinResponse, Task> handler) {
          app.Run(context => {
            if(context.Request.Path.Value == path) {
              context.Request.ContentType = "text/plain";
              handler.ToString();
              return context.Response.WriteAsync("Hello World");
            }
            //context.Response.StatusCode = 404;
            return Task.Delay(0);
          });

    */

    /*
        public void post(string path, Func<IOwinRequest, IOwinResponse, Task> handler) {
          app.Run(context => {
            if(context.Request.Path.Value == path) {
              context.Request.ContentType = "text/plain";
              return handler.Invoke(context.Request, context.Response);
            }
            context.Response.StatusCode = 404;
            return Task.Delay(0);
          });
        }

        public void put(string path, Func<IOwinRequest, IOwinResponse, Task> handler) {
          app.Run(context => {
            if(context.Request.Path.Value == path) {
              context.Request.ContentType = "text/plain";
              return handler.Invoke(context.Request, context.Response);
            }
            context.Response.StatusCode = 404;
            return Task.Delay(0);
          });
        }

        public void patch(string path, Func<IOwinRequest, IOwinResponse, Task> handler) {
          app.Run(context => {
            if(context.Request.Path.Value == path) {
              context.Request.ContentType = "text/plain";
              return handler.Invoke(context.Request, context.Response);
            }
            context.Response.StatusCode = 404;
            return Task.Delay(0);
          });
        }
    */
    public void address( string path, Func<IOwinRequest, IOwinResponse, Task> handler ) { }
    public void listen( string path, Func<IOwinRequest, IOwinResponse, Task> handler ) { }
    public void close( string path, Func<IOwinRequest, IOwinResponse, Task> handler ) { }
    public void param( string path, Func<IOwinRequest, IOwinResponse, Task> handler ) { }
    public void rm( string path, Func<IOwinRequest, IOwinResponse, Task> handler ) { }
    public void use( string path, Func<IOwinRequest, IOwinResponse, Task> handler ) { }
    public void pre( string path, Func<IOwinRequest, IOwinResponse, Task> handler ) { }
    public void toString( string path, Func<IOwinRequest, IOwinResponse, Task> handler ) { }


  }
}
