using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CHapi
{
    public class Route
    {
        public HttpMethod Method { get; set; }
        public string Path { get; set; }
        public Expression Handler { get; set; }
        public Type[] Types { get; set; }
    }
}
