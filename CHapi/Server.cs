using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using System.Net.Http;
using System.Linq.Expressions;
using Owin;
using System.Dynamic;

namespace CHapi
{
    public class Server
    {
        private readonly IJsonSerializer jsonSerializer;

        public Server(){
            this.jsonSerializer = new JsonNetSerializer();
        }
        public void Connection(string host, int port) { 
            //todo
        }

        public void Route(HttpMethod method, string path, Expression<Func<Request, object>> handler) { 
            //todo
        }

        public void Start() {
            WebApp.Start(new StartOptions { Port = 8000 }, startup =>
            {
                startup.Run(context =>
                {
                    var res = "hello world";
                    context.Response.StatusCode = 200;
                    context.Response.WriteAsync(jsonSerializer.Serialize(res));
                    return Task.Delay(0);
                });
            });
        }
    }
}
