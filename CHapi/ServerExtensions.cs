using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CHapi
{
    public static class ServerExtensions
    {
        public static void Route(this Server server, HttpMethod method, string path, Expression<Func<Request, object>> handler)
        {
            server.Route(method, path, handler);
        }

        public static void Route<T1>(this Server server, HttpMethod method, string path, Expression<Func<Request, T1, object>> handler)
        {
            server.Route(method, path, handler, typeof(T1));
        }

        public static void Route<T1, T2>(this Server server, HttpMethod method, string path, Expression<Func<Request, T1, T2, object>> handler)
        {
            server.Route(method, path, handler, typeof(T1), typeof(T2));
        }

        public static void Route<T1, T2, T3>(this Server server, HttpMethod method, string path, Expression<Func<Request, T1, T2, T3, object>> handler)
        {
            server.Route(method, path, handler, typeof(T1), typeof(T2), typeof(T3));
        }

        public static void Route<T1, T2, T3, T4>(this Server server, HttpMethod method, string path, Expression<Func<Request, T1, T2, T3, T4, object>> handler)
        {
            server.Route(method, path, handler, typeof(T1), typeof(T2), typeof(T3), typeof(T4));
        }

        public static void Route<T1, T2, T3, T4, T5>(this Server server, HttpMethod method, string path, Expression<Func<Request, T1, T2, T3, T4, T5, object>> handler)
        {
            server.Route(method, path, handler, typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5));
        }

        public static void Route<T1, T2, T3, T4, T5, T6>(this Server server, HttpMethod method, string path, Expression<Func<Request, T1, T2, T3, T4, T5, T6, object>> handler)
        {
            server.Route(method, path, handler, typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6));
        }

        public static void Route<T1, T2, T3, T4, T5, T6, T7>(this Server server, HttpMethod method, string path, Expression<Func<Request, T1, T2, T3, T4, T5, T6, T7, object>> handler)
        {
            server.Route(method, path, handler, typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7));
        }

        public static void Route<T1, T2, T3, T4, T5, T6, T7, T8>(this Server server, HttpMethod method, string path, Expression<Func<Request, T1, T2, T3, T4, T5, T6, T7, T8, object>> handler)
        {
            server.Route(method, path, handler, typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8));
        }

        public static void Route<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Server server, HttpMethod method, string path, Expression<Func<Request, T1, T2, T3, T4, T5, T6, T7, T8, T9, object>> handler)
        {
            server.Route(method, path, handler, typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9));
        }

        public static void Route<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Server server, HttpMethod method, string path, Expression<Func<Request, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, object>> handler)
        {
            server.Route(method, path, handler, typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10));
        }

        public static void Route<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Server server, HttpMethod method, string path, Expression<Func<Request, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object>> handler)
        {
            server.Route(method, path, handler, typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11));
        }

        public static void Route<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Server server, HttpMethod method, string path, Expression<Func<Request, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, object>> handler)
        {
            server.Route(method, path, handler, typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12));
        }

        public static void Route<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Server server, HttpMethod method, string path, Expression<Func<Request, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object>> handler)
        {
            server.Route(method, path, handler, typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13));
        }

        public static void Route<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Server server, HttpMethod method, string path, Expression<Func<Request, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, object>> handler)
        {
            server.Route(method, path, handler, typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14));
        }

        public static void Route<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Server server, HttpMethod method, string path, Expression<Func<Request, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, object>> handler)
        {
            server.Route(method, path, handler, typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15));
        }
    }
}
