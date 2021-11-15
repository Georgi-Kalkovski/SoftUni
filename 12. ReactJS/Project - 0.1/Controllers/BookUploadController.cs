using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookcase.Models;
using System;

namespace MyBookcase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookUploadController : ControllerBase
    {
        [HttpPost]
        [Route("upload")]
        public void Upload(BookUploadViewModel viewModel)
        {
            int commaIndex = viewModel.Base64File.IndexOf(',');
            string base64 = viewModel.Base64File.Substring(commaIndex + 1);

            byte[] fileData = Convert.FromBase64String(base64);
            System.IO.File.WriteAllBytes($"wwwroot/Uploads/{viewModel.Name}", fileData);
        }
    }
}
