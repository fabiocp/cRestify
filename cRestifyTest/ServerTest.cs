using System;
using System.Text;
using System.Threading.Tasks;
using cRestify;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using NUnit.Framework;
using System.Net.Http;
using Should;

namespace cRestifyTest {

  public class Item {
    public int Numero { get; set; }
  }

  public class Todo {
    public string HelloWord() {
      return "Hello World";
    }

    public Item[] list() {
      return new Item[] { new Item { Numero = 1 }, new Item { Numero = 2 } };
    }

    public Item show(int id) {
      return new Item { Numero = id };
    }

    public void novo(int id, string name) {
      //do alguma coisa
    }

    /*   env.Get("/list");
        env.Get("/show/:id");
        env.Get("/new");*/

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
        //server.Get("Todo", "/WhyNot/:p1/:p2");
        //server.Get("Todo", new {"/WhyNotForUrl/:p1/:p2", "WhyNot"});
        //server.Get("Todo", 
        //    new {url="/WhyNotForUrl/:p1/:p2", action="WhyNot"}, 
        //    "/OtherWhyNot/:p1/:p2", 
        //    new {url="/YetAnother/:p1/:p2/:p3", action="DoesItMustLooksLikeRestify"}); //params object[]
      });

      var client = new HttpClient();
      client.GetStringAsync("http://localhost:8080/helloWord").Result.ShouldEqual("\"Hello World\"");

    }

    [Test]
    public void TestMethodItem() {

      WebApp.Start(new StartOptions { Port = 8080 }, startup => {
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

    [Test]
    public void TestResource() {

      WebApp.Start(new StartOptions { Port = 8080 }, startup => {
        var restify = new Restify(startup);
        var server = restify.CreateServer();
        server.Resource<Todo>("/todoResource", env => {
          env.Get("/HelloWord");
        });
      });

      var client = new HttpClient();
      client.GetStringAsync("http://localhost:8080/todoResource/helloWord").Result.ShouldEqual("\"Hello World\"");
    }


    [Test]
    public void TestMethod3() {

      WebApp.Start(new StartOptions { Port = 8080 }, startup => {
        var restify = new Restify(startup);
        var server = restify.CreateServer();
        server.Resource<Todo>("/todo", env => {
          env.Get("/list");
          env.Get("/show/:id");
          //env.Get("/new");
          env.Get("/novo/:id/:name");
        });
      });

      var client = new HttpClient();
      //client.GetStringAsync("http://localhost:8080/todo/helloWord").Result.ShouldEqual("Hello World");
      client.GetStringAsync("http://localhost:8080/todo/list").Result.ShouldEqual(@"[{""Numero"":1},{""Numero"":2}]");
      client.GetStringAsync("http://localhost:8080/todo/show/1").Result.ShouldEqual(@"{""Numero"":1}");
      client.GetStringAsync("http://localhost:8080/todo/novo/2/fabio").Result.ShouldEqual("{}");

    }

public void TestRoute()
    {
        WebApp.Start(new StartOptions { Port = 8080 }, startup =>
        {
            var restify = new Restify(startup);
            var server = restify.CreateServer();
            server.Route(
               "GET",
               "/TestRoute",
               request => {
                   var ret = "123";
                   return ret;
               }
            );
        });

        var client = new HttpClient();
        client.GetStringAsync("http://localhost:8080/TestRoute").Result.ShouldEqual("\"123\"");
    }
    
    [Test]
    public void TestRouteWithParams()
    {
        WebApp.Start(new StartOptions { Port = 8080 }, startup =>
        {
            var restify = new Restify(startup);
            var server = restify.CreateServer();
            server.Route(
               "GET",
               "/TestRoute",
               request =>
               {
                   request.GetParams();
                   var ret = "123";
                   return ret;
               }
            );
        });

        var client = new HttpClient();
        client.GetStringAsync("http://localhost:8080/TestRoute").Result.ShouldEqual("\"123\"");
    }


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
