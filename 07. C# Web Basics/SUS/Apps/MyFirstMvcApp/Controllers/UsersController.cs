using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.IO;
using System.Text;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            return View();
        }

        public HttpResponse Register(HttpRequest request)
        {
            return View();
        }

        public HttpResponse DoLogin(HttpRequest request)
        {
            return Redirect("/");
        }
    }
}