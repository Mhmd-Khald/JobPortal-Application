using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Apis.Helpers;
using System.IO;

namespace Project.Apis.Controllers
{

    public class FilesController : BaseApiController
    {
        private readonly IWebHostEnvironment _WebHost;
        private readonly Helper _helper;

        public FilesController(IWebHostEnvironment webHost , Helper helper)
        {
            _WebHost = webHost;
            _helper = helper;
        }
        [HttpPost]
        public IActionResult UploadFiles (IFormFile file)
        {
            var cvUrl =  _helper.UploadImage(file, Request.Scheme, Request.Host);
            return Ok();

        }
            

    }
}
