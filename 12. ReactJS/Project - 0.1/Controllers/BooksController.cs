using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace MyBookcase.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult ViewBook(string name)
        {
            byte[] bookData = System.IO.File.ReadAllBytes($"wwroot/Uploads/{name}");
            return File(bookData, "APPLICATION/octet-stream", name);
        }

        /*
        public IActionResult GetCsv()
        {
            var foo = "hello,world";
            var bytes = Encoding.UTF8.GetBytes(foo);
            return File(bytes, "text/csv", "test.csv");
        }
        */
    }
}
