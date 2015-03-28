using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Should;
using CHapi;

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

        /*
        [TestMethod]
        public void TestDynamicParams()
        {
            var server = new CHapi.Server();
            server.Connection(
                host: "localhost",
                port: 8001
            );

            // Add the route
            server.Route(
                method: CHapi.HttpMethod.Get,
                path: "/testparams/{id}/{nome}",
                handler: request => "ola "// + request.Params.name + " ("+request.Params.id+")"
            );

            // Start the server
            server.Start();

            var client = new HttpClient();
            client.GetStringAsync("http://localhost:8000/testeparams/1/juca").Result.ShouldEqual("\"ola juca (1)\"");
        }*/

        [TestMethod]
        public void TestGenericParam()
        {
            var server = new CHapi.Server();
            server.Connection(
                host: "localhost",
                port: 8001
            );

            // Add the route
            server.Route<int, string>(
                method: CHapi.HttpMethod.Get,
                path: "/testparams/{id}/{nome}",
                handler: (request, id, nome) => "ola " + nome + " (" + id.ToString() + ")"
            );

            // Start the server
            server.Start();

            var client = new HttpClient();
            client.GetStringAsync("http://localhost:8000/testeparams/1/juca").Result.ShouldEqual("\"ola juca (1)\"");
        }


    }
}
