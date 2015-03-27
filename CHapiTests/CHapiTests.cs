using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Should;

namespace cRestifyTest
{
    [TestClass]
    public class CHapiTests
    {
        [TestMethod]
        public void TestGettingStarted()
        {
            var server = new CHapi.Server();
            server.Connection(
                host: "localhost",
                port: 8001
            );

            // Add the route
            server.Route(
                method: CHapi.HttpMethod.Get,
                path: "/helloWord",
                handler: request => "hello world"
            );

            // Start the server
            server.Start();

            var client = new HttpClient();
            client.GetStringAsync("http://localhost:8000/helloWord").Result.ShouldEqual("\"hello world\"");
        }

    }
}
