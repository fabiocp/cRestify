﻿using System;
using System.Threading.Tasks;
using cRestify;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using NUnit.Framework;
using System.Net.Http;
using Should;

namespace cRestifyTest {

  class Todo {
    public string HelloWord() {
      return "Hello World";
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
      client.GetStringAsync("http://localhost:8080/helloWord").Result.ShouldEqual("Hello World");

    }

    [Test]
    public void TestMethod2() {

      WebApp.Start(new StartOptions { Port = 8080 }, startup => {
        var restify = new Restify(startup);
        var server = restify.CreateServer();
        server.Get<Todo>("/helloWord", env => env.HelloWord());
      });

      var client = new HttpClient();
      client.GetStringAsync("http://localhost:8080/helloWord").Result.ShouldEqual("Hello World");

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
  }
}