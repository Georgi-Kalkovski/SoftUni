using SUS.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.MvcFramework
{
    public class Route
    {
        public Route(string path,HttpMethod method, Func<HttpRequest, HttpResponse> action)
        {
            Path = path;
            Method = method;
            Action = action;
        }

        public string Path { get; set; }

        public HttpMethod Method { get; set; }

        public Func<HttpRequest, HttpResponse> Action { get; set; }
    }
}
