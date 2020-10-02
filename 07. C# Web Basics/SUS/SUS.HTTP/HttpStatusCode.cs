using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.HTTP
{
    public enum HttpStatusCode
    {
        Ok = 200,
        MovedPermanently = 301,
        Found = 302,
        TemporaryRedirect = 307,
        NotFound =404,
        ServerError =500,
    }
}
