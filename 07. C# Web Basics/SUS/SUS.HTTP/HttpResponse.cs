using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.HTTP
{
    public class HttpResponse
    {
        public HttpResponse(string contentType, byte[] body, HttpStatusCode statusCode = HttpStatusCode.Ok)
        {
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            StatusCode = statusCode;
            Body = body;
            Headers = new List<Header>
            {
                { new Header("Content-Type", contentType)},
                { new Header("Content-Length", body.Length.ToString())},
            };
            Cookies = new List<Cookie>();
        }

        public override string ToString()
        {
            StringBuilder responseBuilder = new StringBuilder();
            responseBuilder.Append($"HTTP/1.1 {(int)StatusCode} {StatusCode}" + HttpConstants.NewLine);
            foreach (var header in Headers)
            {
                responseBuilder.Append(header.ToString() + HttpConstants.NewLine);
            }

            foreach (var cookie in Cookies)
            {
                responseBuilder.Append("HashSet-Cookie:" + cookie.ToString() + HttpConstants.NewLine);
            }

            responseBuilder.Append(HttpConstants.NewLine);
            return responseBuilder.ToString();

        }

        public HttpStatusCode StatusCode { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<Cookie> Cookies { get; set; }

        public byte[] Body { get; set; }
    }
}
