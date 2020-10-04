using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.IO;

namespace MyFirstMvcApp.Controllers
{
    public class StaticFilesController : Controller
    {
        public HttpResponse Favicon(HttpRequest request)
        {
            return File("wwwroot/favicon.ico", "image/vnd.microsoft.icon");
        }
      
        internal HttpResponse BootstrapCss(HttpRequest arg)
        {
            return File("wwwroot/css/bootstrap.min.css", "text/css");
        }

        internal HttpResponse CustomCss(HttpRequest arg)
        {
            return File("wwwroot/css/custom.css", "text/css");
        }

        internal HttpResponse BootstrapJs(HttpRequest arg)
        {
            return File("wwwroot/js/bootstrap.bundle.min.js", "text/javascript");
        }
        public HttpResponse CustomJs(HttpRequest arg)
        {
            return File("wwwroot/js/custom.js", "text/javascript");
        }

    }
}
