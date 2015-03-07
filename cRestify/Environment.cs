using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Fasterflect;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace cRestify
{
    public class Environment
    {
        private UrlParser urlParser;

        public string RootPath { get; private set; }

        private IDictionary<string, string>  Urls;

        public Environment(string rootPath)
        {
            this.RootPath = rootPath;
            this.Urls = new Dictionary<string, string>();
            this.urlParser = new UrlParser();
        }

        public void Get(string url) {
            Urls.Add(url, "GET");
        }

        public bool AnyUrl(string methodName, string method, out string route) {
            route = null;
            if (Urls.Any(k => urlParser.GetResourceName(k.Key) == methodName && k.Value == method))
            {
                route = Urls.First(k => urlParser.GetResourceName(k.Key) == methodName && k.Value == method).Key;
                return true;
            }
            return false;
        }
    }
}
