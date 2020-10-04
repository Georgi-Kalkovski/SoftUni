using SUS.HTTP;
using System;

namespace SUS.HTTP
{
    public class Route
    {
        public Route(string path, Func<HttpRequest, HttpResponse> action)
        {
            Path = path;
            Action = action;
        }

        public string Path { get; set; }

        public Func<HttpRequest, HttpResponse> Action { get; set; }
    }
}
