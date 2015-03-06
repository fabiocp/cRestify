using System;
using System.Threading.Tasks;
using cRestify;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using NUnit.Framework;
using System.Net.Http;
using Should;

namespace cRestifyTest {

    class Item {
        public int Numero { get; set; }
    }

  class Todo {
    public string HelloWord() {
      return "Hello World";
    }

    public Item GetItem() {
        return new Item { Numero = 1 };
    }
  }

  [TestFixture]
  public class ServerTest {

    [Test]
    public void TestMethod1() {

      WebApp.Start(new StartOptions { Port = 8080 }, startup => {
        var restify = new Restify(startup);
        var server = restify.CreateServer();
        server.Get<Todo, string>("/helloWord", env => env.HelloWord());
      });

      var client = new HttpClient();
      client.GetStringAsync("http://localhost:8080/helloWord").Result.ShouldEqual("\"Hello World\"");

    }

    [Test]
    public void TestMethodItem()
    {

        WebApp.Start(new StartOptions { Port = 8080 }, startup =>
        {
            var restify = new Restify(startup);
            var server = restify.CreateServer();
            server.Get<Todo, Item>("/obterItem", env => env.GetItem());
        });

        var client = new HttpClient();
        var res = client.GetStringAsync("http://localhost:8080/obterItem").Result;
        res.ShouldEqual(@"{""Numero"":1}");

    }


    [Test]
    public void TestMethod2() {

      WebApp.Start(new StartOptions { Port = 8080 }, startup => {
        var restify = new Restify(startup);
        var server = restify.CreateServer();
        server.Get<Todo>("/helloWord", env => env.HelloWord());
      });

      var client = new HttpClient();
      client.GetStringAsync("http://localhost:8080/helloWord").Result.ShouldEqual("");

    }
/*
    [Test]
    public void TestMethod3() {

      WebApp.Start(new StartOptions { Port = 8080 }, startup => {
        var restify = new Restify(startup);
        var server = restify.CreateServer();
        server.Resource<Todo>("/todo", env => {
          env.Get("/list");
          env.Get("/show/:id");
          env.Get("/new");
        });
      });

      var client = new HttpClient();
      client.GetStringAsync("http://localhost:8080/helloWord").Result.ShouldEqual("Hello World");

    }*/

     
    /*[Test]
    public void TestMethod3() {

      WebApp.Start(new StartOptions { Port = 8080 }, startup => {
        var restify = new Restify(startup);
        var server = restify.CreateServer();
        server.Resource<Todo>("/todo", env => {
          env.Get("/list");
          env.Get("/show/:id");
          env.Get("/new");
        });
      });

      var client = new HttpClient();
      client.GetStringAsync("http://localhost:8080/helloWord").Result.ShouldEqual("Hello World");

    }*/
  }
}
