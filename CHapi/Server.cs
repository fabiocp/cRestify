using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using System.Net.Http;
using System.Linq.Expressions;
using Owin;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;

namespace CHapi
{
    public class Server
    {
        #region Private Fields
        private readonly IJsonSerializer jsonSerializer;
        private IList<Route> routes;
        #endregion

        #region Constructors
        public Server()
        {
            this.jsonSerializer = new JsonNetSerializer();
            this.routes = new List<Route>();
        }
        #endregion

        #region Public Methods
        public void Connection(string host, int port)
        {
            //todo
        }

        public void Route(HttpMethod method, string path, Expression handler, params Type[] types)
        {
            routes.Add(new Route
            {
                Method = method,
                Path = path,
                Handler = handler,
                Types = types
            });
        }

        public void Start()
        {
            WebApp.Start(new StartOptions { Port = 8000 }, startup =>
            {
                startup.Run(context =>
                {
                    var res = "";
                    if (context.Request.Uri.AbsolutePath.Contains("helloWord"))
                    {
                        res = "hello world";
                    }
                    else {
                        res = "ola juca (1)";
                    }
                    context.Response.StatusCode = 200;
                    context.Response.WriteAsync(jsonSerializer.Serialize(res));
                    return Task.Delay(0);
                });
            });
        }

        #endregion
    }
}
